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
using System.Linq;
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


    public ObservableCollection<Organization> Organizations { get; set; }
    public Organization Organization { get; set; }
    public ReactiveCommand<Organization, Window> Employes;

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

        Task.Run(() => Inintialize());
    }

    private async Task Inintialize()
    {
        _logger.LogInformation("Inintialize HomeViewModel.");

        Organizations = await _viewModelService.GetOrganizations();
    }
}