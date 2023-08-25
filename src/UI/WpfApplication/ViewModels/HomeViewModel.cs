using Castle.Core.Logging;
using DynamicData;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Wpf;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Security;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;

namespace Metcom.CardPay3.WpfApplication.ViewModels;
public class HomeViewModel : ReactiveObject, IRoutableViewModel
{
    public string UrlPathSegment { get { return "Home"; } }
    public IScreen HostScreen { get; protected set; }

    [Reactive]
    public ObservableCollection<Organization> Organizations { get; set; }

    [Reactive]
    public Organization SelectedOrganization { get; set; }

    [Reactive]
    public bool IsRealOrganization { get; set; }

    private readonly IRepository<Organization> _repository;
    private readonly ILogger<HomeViewModel> _logger;
    private readonly IHomeViewModelService _viewModelService;

    public HomeViewModel(
        IRepository<Organization> repository,
        ILogger<HomeViewModel> logger,
        IHomeViewModelService viewModelService,
        IScreen screen = null)
    {
        HostScreen = screen;

        _repository = repository ?? Locator.Current.GetService<IRepository<Organization>>();
        _logger = logger ?? Locator.Current.GetService<ILogger<HomeViewModel>>();
        _viewModelService = viewModelService ?? Locator.Current.GetService<IHomeViewModelService>();

        // commands
        RoutingEmployeeCommand = ReactiveCommand.Create(delegate ()
        {
            Router.Navigate.Execute(Locator.Current.GetService<EmployeeListViewModel>());
        });
        RoutingAccrualCommand = ReactiveCommand.Create(delegate ()
        {
            Router.Navigate.Execute(Locator.Current.GetService<AccrualListViewModel>());
        });
        RoutingCreateOrganizationCommand = ReactiveCommand.Create(delegate ()
        {
            Router.Navigate.Execute(Locator.Current.GetService<CreateOrganizationViewModel>());
        });
        RoutingCommand = ReactiveCommand.Create<Constants.RoutingIDs>(ExecuteSidebar);

        Initialize();
    }

    private async void Initialize()
    {
        _logger.LogInformation("Inintialize HomeViewModel.");

        Organizations = await _viewModelService.GetOrganizations();

        this.WhenAnyValue(vm => vm.SelectedOrganization).Subscribe(_ => UpdateIsRealOrganization());
    }

    public RoutingState Router { get; }

    #region commands

    public ReactiveCommand<Unit, Unit> RoutingEmployeeCommand { get; }
    public ReactiveCommand<Unit, Unit> RoutingCreateOrganizationCommand { get; }
    public ReactiveCommand<Unit, Unit> RoutingAccrualCommand { get; }

    public ReactiveCommand<Constants.RoutingIDs, Unit> RoutingCommand { get; }

    private void ExecuteSidebar(Constants.RoutingIDs parameter)
    {
        switch (parameter)
        {
            //case Constants.RoutingIDs.Mods:
            //    Router.Navigate.Execute(Locator.Current.GetService<ModListViewModel>());
            //    break;
            case Constants.RoutingIDs.AccrualList:
                Router.Navigate.Execute(Locator.Current.GetService<AccrualListViewModel>());
                break;
            case Constants.RoutingIDs.EmployeeList:
                Router.Navigate.Execute(Locator.Current.GetService<EmployeeListViewModel>());
                break;
            case Constants.RoutingIDs.Main:
                break;
            //case Constants.RoutingIDs.Search:
            //    Router.Navigate.Execute(Locator.Current.GetService<SearchViewModel>());
            //    break;
            default:
                throw new ArgumentOutOfRangeException(nameof(parameter), parameter, null);
        }
    }
    #endregion

    private void UpdateIsRealOrganization()
    {
        if (SelectedOrganization == null)
        {
            IsRealOrganization = false;
        }
        else if (SelectedOrganization.Name == "Создать организацию.")
        {
            IsRealOrganization = false;
            Router.Navigate.Execute(Locator.Current.GetService<CreateOrganizationViewModel>());
        }
        else
        {
            IsRealOrganization = true;
        }
    }
}