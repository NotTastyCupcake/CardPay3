﻿using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;

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

        //this.ValidationRule(
        //    viewModel => viewModel.Organizations,
        //    item => item != null && item.Count > 1, "Не возможно удалить выбранную организацию");

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

        var canDeleteOrg = this
            .WhenAnyValue(x => x.Organizations.Count)
            .Select(count => count > 1);
        DeleteOrganization = ReactiveCommand.Create(DeleteSelectedOrg(), canDeleteOrg);

        Task.Run(() => Initialize());
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
        else
        {
            await Router.Navigate.Execute(Locator.Current.GetService<CreateOrganizationViewModel>());
        }
        
    }

    public RoutingState Router { get; }

    #region commands
    public ReactiveCommand<Unit, Unit> RoutingCreateOrganizationCommand { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> RoutingGoBackCommand { get; }

    public ReactiveCommand<string, Unit> RoutingCommand { get; }
    public ReactiveCommand<Unit, Unit> DeleteOrganization { get; }


    private Action DeleteSelectedOrg()
    {
        return async delegate ()
        {
            await _repository.DeleteAsync(SelectedOrganization);
            await _repository.SaveChangesAsync();

            Organizations.Remove(SelectedOrganization);
            SelectedOrganization = Organizations[0];
        };
    }

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
    #endregion
}