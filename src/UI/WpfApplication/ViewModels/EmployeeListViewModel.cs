﻿using Castle.Core.Logging;
using DynamicData;
using DynamicData.Binding;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.Infrastructure.Data;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes;
using Metcom.CardPay3.WpfApplication.Views.Employes;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Reactive;
using System.Reactive.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;

namespace Metcom.CardPay3.WpfApplication.ViewModels
{
    public class EmployeeListViewModel : ReactiveObject, IRoutableViewModel, IDisposable
    {
        public string UrlPathSegment { get { return "EmployeeList"; } }
        public IScreen HostScreen { get; protected set; }

        private readonly IRepository<Employe> _itemRepository;
        private readonly ILogger<EmployeeListViewModel> _logger;
        private readonly IEmployeViewModelService _employeViewModelService;
        private readonly IDisposable _cleanUp;

        public EmployeeListViewModel(
            IEmployeViewModelService viewModelService,
            ILogger<EmployeeListViewModel> logger,
            IRepository<Employe> itemRepository,
            IScreen screen = null)
        {
            _employeViewModelService = viewModelService;
            _logger = logger;

            _itemRepository = itemRepository;

            HostScreen = screen;
            
            // commands
            RoutingAddEmployeeCommand = ReactiveCommand.Create(delegate ()
            {
                HostScreen.Router.Navigate.Execute(Locator.Current.GetService<AddEmployeViewModel>());
            });
            RoutingDeleteEmployeeCommand = ReactiveCommand.Create(DeleteEmploye());

            //Init collection
            ReadOnlyObservableCollection<Employe> bindingData;
            var items = Task.Run(() => _employeViewModelService.GetEmployes(SelectedOrganization?.Id)).Result;

            _cleanUp = items
                .Sort(SortExpressionComparer<Employe>.Ascending(t => t.FullName))
                .Bind(out bindingData)
                .Subscribe();

            Employes = bindingData;

            Task.Run(() => Initialize());
        }

        private async Task Initialize()
        {
            _logger.LogInformation("Inintialize EmployeeListViewModel.");

            //this.WhenAnyValue(vm => vm.SelectedEmploye).Subscribe();
        }

        private Action<int> DeleteEmploye()
        {
            return async (int id) =>
            {
                var employe = await _itemRepository.GetByIdAsync(id);
                await _itemRepository.DeleteAsync(employe);
                await HostScreen.Router.Navigate.Execute(Locator.Current.GetService<AddEmployeViewModel>());
            };
        }

        #region commands
        public ReactiveCommand<int, Unit> RoutingEditEmployeeCommand { get; }
        public ReactiveCommand<Unit, Unit> RoutingAddEmployeeCommand { get; }
        public ReactiveCommand<int, Unit> RoutingDeleteEmployeeCommand { get; }
        #endregion

        #region Properties
        public ReadOnlyObservableCollection<Employe> Employes { get; }

        [Reactive]
        public Employe SelectedEmploye { get; set; }

        [Reactive]
        public Organization SelectedOrganization { get; set; }
        #endregion

        public void Dispose()
        {
            _cleanUp.Dispose();
        }
    }
}