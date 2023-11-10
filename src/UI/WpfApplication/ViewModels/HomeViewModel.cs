﻿using Castle.Core.Logging;
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
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Security;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Metcom.CardPay3.WpfApplication.ViewModels;
public class HomeViewModel : ReactiveObject, IScreen
{
    private readonly IRepository<Organization> _repository;
    private readonly ILogger<HomeViewModel> _logger;
    private readonly IHomeViewModelService _viewModelService;

    public HomeViewModel(
        IRepository<Organization> repository,
        ILogger<HomeViewModel> logger,
        IHomeViewModelService viewModelService)
    {
        Router = new RoutingState();

        _repository = repository ?? Locator.Current.GetService<IRepository<Organization>>();
        _logger = logger ?? Locator.Current.GetService<ILogger<HomeViewModel>>();
        _viewModelService = viewModelService ?? Locator.Current.GetService<IHomeViewModelService>();

        // commands
        RoutingCreateOrganizationCommand = ReactiveCommand.Create(delegate ()
        {
            Router.Navigate.Execute(Locator.Current.GetService<CreateOrganizationViewModel>());
        });

        var canGoBack = this
            .WhenAnyValue(x => x.Router.NavigationStack.Count)
            .Select(count => count > 1);
        RoutingGoBackCommand = ReactiveCommand.CreateFromObservable(() => 
        Router.NavigateBack.Execute(Unit.Default), canGoBack);

        RoutingCommand = ReactiveCommand.Create<string>(ExecuteSidebar);

        Task.Run(() => Initialize());
    }



    private async Task Initialize()
    {
        _logger.LogInformation("Inintialize HomeViewModel.");

        Organizations = await _viewModelService.GetOrganizations();
        SelectedOrganization = Organizations.FirstOrDefault();

        //exec menu
        MenuViewModel = Locator.Current.GetService<MenuViewModel>();
        MenuViewModel.SelectedOrganization = SelectedOrganization;
        await Router.Navigate.Execute(MenuViewModel);

        this.WhenAnyValue(vm => vm.SelectedOrganization).Subscribe(_ => UpdateOrganization());
        
    }

    public RoutingState Router { get; }

    #region commands
    public ReactiveCommand<Unit, Unit> RoutingCreateOrganizationCommand { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> RoutingGoBackCommand { get; }

    public ReactiveCommand<string, Unit> RoutingCommand { get; }

    private void ExecuteSidebar(string parameter)
    {
        switch (parameter)
        {
            //case Constants.RoutingIDs.Mods:
            //    Router.Navigate.Execute(Locator.Current.GetService<ModListViewModel>());
            //    break;
            case "AccrualList":
                Router.Navigate.Execute(Locator.Current.GetService<AccrualListViewModel>());
                break;
            case "EmployeeList":
                Router.Navigate.Execute(Locator.Current.GetService<EmployeeListViewModel>());
                break;
            case "Menu":
                Router.Navigate.Execute(Locator.Current.GetService<MenuViewModel>());
                break;
            //case Constants.RoutingIDs.Search:
            //    Router.Navigate.Execute(Locator.Current.GetService<SearchViewModel>());
            //    break;
            default:
                throw new ArgumentOutOfRangeException(nameof(parameter), parameter, null);
        }
    }
    #endregion

    #region params
    [Reactive]
    public ObservableCollection<Organization> Organizations { get; set; }

    [Reactive]
    public Organization SelectedOrganization { get; set; }

    public MenuViewModel MenuViewModel { get; set; }
    #endregion

    private void UpdateOrganization()
    {
        
        MenuViewModel.SelectedOrganization = SelectedOrganization;
    }
}