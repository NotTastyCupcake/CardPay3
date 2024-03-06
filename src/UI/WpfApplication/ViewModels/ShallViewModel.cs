using DynamicData;
using MaterialDesignThemes.Wpf;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes;
using Metcom.CardPay3.WpfApplication.ViewModels.Organizations;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Windows;

namespace Metcom.CardPay3.WpfApplication.ViewModels;
public class ShallViewModel : ReactiveObject, IScreen
{
    private readonly IRepository<Organization> _repository;
    private readonly ILogger<ShallViewModel> _logger;
    private readonly IHomeViewModelService _viewModelService;
    private readonly IDataExportService _exportService;

    public ShallViewModel(
        IRepository<Organization> repository,
        ILogger<ShallViewModel> logger,
        IHomeViewModelService viewModelService,
        IDataExportService exportService)
    {
        Router = new RoutingState();

        _repository = repository ?? Locator.Current.GetService<IRepository<Organization>>();
        _logger = logger ?? Locator.Current.GetService<ILogger<ShallViewModel>>();
        _viewModelService = viewModelService ?? Locator.Current.GetService<IHomeViewModelService>();
        _exportService = exportService ?? Locator.Current.GetService<IDataExportService>();

        //this.ValidationRule(
        //    viewModel => viewModel.Organizations,
        //    item => item != null && item.Count > 1, "Не возможно удалить выбранную организацию");

        // commands
        var canDeleteOrg = this
            .WhenAnyValue(x => x.Organizations.Count, x => x.SelectedOrganization.Name)
            .Select(obj => obj.Item1 > 1 && obj.Item2 != "Создать организацию.");

        var canGoBack = this
            .WhenAnyValue(x => x.Router.NavigationStack.Count, x => x.Organizations.Count)
        .Select(count => count.Item1 > 1 && count.Item2 > 1);

        RoutingGoBackCommand = ReactiveCommand.CreateFromObservable(() => 
        { 
            if(SelectedOrganization.Name == "Создать организацию.")
            {
                SelectedOrganization = Organizations.First(x => x.Name != "Создать организацию.");
            }

            return Router.NavigateBack.Execute(Unit.Default); 
        },
        canGoBack);

        RoutingCommand = ReactiveCommand.Create<string>(async delegate(string parameter)    {
            switch (parameter)
            {
                //case Constants.RoutingIDs.Mods:
                //    Router.Navigate.Execute(Locator.Current.GetService<ModListViewModel>());
                //    break;
                case "AccrualList":
                    await Router.Navigate.Execute(Locator.Current.GetService<AccrualListViewModel>());
                    break;
                case "EmployeeList":
                    await Router.Navigate.Execute(Locator.Current.GetService<EmployeeListViewModel>());
                    break;
                case "Menu":
                    await Router.Navigate.Execute(Locator.Current.GetService<MenuViewModel>());
                    break;
                //case Constants.RoutingIDs.Search:
                //    Router.Navigate.Execute(Locator.Current.GetService<SearchViewModel>());
                //    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(parameter), parameter, null);
            }
        });

        DeleteOrganization = ReactiveCommand.CreateFromTask(async delegate ()
        {
            await _repository.DeleteAsync(SelectedOrganization);
            await _repository.SaveChangesAsync();

            Organizations.Remove(SelectedOrganization);
            SelectedOrganization = Organizations[0];

        }, canDeleteOrg);

        RoutingCreateOrganizationCommand = ReactiveCommand.CreateFromTask(async delegate ()
        {
            await Router.Navigate.Execute(Locator.Current.GetService<CreateOrganizationViewModel>());
        }, canDeleteOrg);

        RoutingEditOrganizationCommand = ReactiveCommand.CreateFromTask(async delegate()
        {
            await Router.Navigate.Execute(Locator.Current.GetService<EditOrganizationViewModel>());
        }, canDeleteOrg);

        RoutingSettingsCommand = ReactiveCommand.CreateFromTask(async delegate ()
        {
            var settingsWindow = Locator.Current.GetService<IViewFor<SettingsViewModel>>();

            if(settingsWindow is Window window )
            {
                window.Show();
            }
            
        });

        ExportOrganizationCommand = ReactiveCommand.CreateFromTask(async delegate ()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Расширяемый язык разметки(*.json)| *.json";
            //"|Расширяемый язык разметки(*.xml)| *.xml"; //Не понятно как преобразовать List<Employe> в XML без атребутов
            if (saveFile.ShowDialog() == true)
            {
                await _exportService.ExportDataAsync(
                    saveFile.SafeFileName.Split('.').LastOrDefault(),
                    saveFile.FileName,
                    SelectedOrganization.Id);
            }
        });

        Task.Run(() => Initialize());

        this.WhenAnyValue(vm => vm.SelectedOrganization).Subscribe(_ => UpdateSelectedOrganization());
    }



    private async Task Initialize()
    {
        _logger.LogInformation("Inintialize HomeViewModel.");

        Organizations = await _viewModelService.GetOrganizations();
        SelectedOrganization = Organizations.FirstOrDefault();

        if(Organizations.Count > 1)
        {
            await Router.Navigate.Execute(Locator.Current.GetService<MenuViewModel>());
        }
        
    }

    public RoutingState Router { get; }

    #region commands
    public ReactiveCommand<Unit, Unit> RoutingCreateOrganizationCommand { get; }
    public ReactiveCommand<Unit, Unit> RoutingEditOrganizationCommand { get; }
    public ReactiveCommand<Unit, Unit> DeleteOrganization { get; }

    public ReactiveCommand<Unit, Unit> RoutingSettingsCommand { get; }

    public ReactiveCommand<Unit, IRoutableViewModel> RoutingGoBackCommand { get; }

    public ReactiveCommand<string, Unit> RoutingCommand { get; }

    public ReactiveCommand<Unit, Unit> ExportOrganizationCommand { get; }

    private void UpdateSelectedOrganization()
    {
        if (SelectedOrganization != null && SelectedOrganization.Name == "Создать организацию.")
        {
            Router.Navigate.Execute(Locator.Current.GetService<CreateOrganizationViewModel>());
        }
    }
    #endregion

    #region params
    [Reactive]
    public ObservableCollection<Organization> Organizations { get; set; }

    [Reactive]
    public Organization SelectedOrganization { get; set; }
    #endregion
}