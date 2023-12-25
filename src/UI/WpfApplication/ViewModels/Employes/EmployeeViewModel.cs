﻿using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Helpers;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes
{
    public class EmployeeViewModel : ReactiveValidationObject, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "Employee"; } }
        public IScreen HostScreen { get; protected set; }

        private readonly IRepository<Employee> _repository;
        private readonly ILogger<EmployeeViewModel> _logger;
        private readonly IEmployeeViewModelService _employeViewModelService;

        public EmployeeViewModel(
            IRepository<Employee> repository,
            ILogger<EmployeeViewModel> logger,
            IEmployeeViewModelService viewModelService,
            IScreen screen = null)
        {
            _repository = repository;
            _logger = logger;
            _employeViewModelService = viewModelService;

            HostScreen = screen;

            Organization = Locator.Current.GetService<MenuViewModel>().SelectedOrganization;

            //Window = Locator.Current.GetService<IViewFor<EmployeeViewModel>>() as Window;

            // commands
            ActionCommand = ReactiveCommand.Create(ActionAndCloseWindowAsync());

            CreateAddress = ReactiveCommand.Create(AddressWindow());

            CreateDocument = ReactiveCommand.Create(DocumentWindow());

            Task.Run(() => Initialize());

            //this.WhenAnyValue(vm => vm.Employe).Subscribe(_ => /*UpdateIsRealOrganization()*/);

        }



        private async Task Initialize()
        {
            Genders = await _employeViewModelService.GetGenders();
            SelectedGender = Genders.FirstOrDefault();

            if (SelectedOperation == Constants.Operations.Edit)
            {
                SelectedGender = Employee.Gender;
                Document = Employee.Document;
                Address = _employeViewModelService.GetAddress(Employee);
                Requisites = _employeViewModelService.GetRequisites(Employee);
                Organization = Employee.Organization;
            }

            this.WhenAnyValue(vm => vm.Employee).Subscribe();
            this.WhenAnyValue(vm => vm.SelectedGender).Subscribe();
            this.WhenAnyValue(vm => vm.Document).Subscribe();
            this.WhenAnyValue(vm => vm.DocumentFullName).Subscribe();
            this.WhenAnyValue(vm => vm.Address).Subscribe();
            this.WhenAnyValue(vm => vm.AddressFullName).Subscribe();
            this.WhenAnyValue(vm => vm.Requisites).Subscribe();
            this.WhenAnyValue(vm => vm.Organization).Subscribe();
        }


        #region commands
        public ReactiveCommand<Unit, Unit> ActionCommand { get; }
        public ReactiveCommand<Unit, Unit> CreateDocument { get; }
        public ReactiveCommand<Unit, Unit> CreateAddress { get; }

        private Action ActionAndCloseWindowAsync()
        {
            return async delegate ()
            {
                Employee.Gender = SelectedGender;
                Employee.Document = Document;
                //TODO: Заполнение адресов в отдельном окне
                //Employee.Addresses = Address;
                Employee.Requisites = Requisites;
                Employee.Organization = Organization;

                //Add
                if (SelectedOperation == Constants.Operations.Create)
                {
                    await _repository.AddAsync(Employee);
                    await _repository.SaveChangesAsync();
                }
                //Edit
                else if (SelectedOperation == Constants.Operations.Edit)
                {
                    await _repository.UpdateAsync(Employee);
                    await _repository.SaveChangesAsync();
                }


                HostScreen.Router.NavigateBack.Execute();
            };
        }

        private Action AddressWindow()
        {
            return delegate ()
            {
                HostScreen.Router.Navigate.Execute(Locator.Current.GetService<AddressViewModel>());
            };
        }

        private Action DocumentWindow()
        {
            return delegate ()
            {
                HostScreen.Router.Navigate.Execute(Locator.Current.GetService<DocumentViewModel>());
            };
        }

        #endregion

        #region properties
        [Reactive]
        public Employee Employee { get; set; } = new Employee();

        [Reactive]
        public Organization Organization { get; set; }
        [Reactive]
        //TODO: Убрать авто заполнение, сделать форму создания документа
        public DocumentItem Document { get; set; }

        public string DocumentFullName { get => Document?.FullName ?? "<Нет данных>"; }
        [Reactive]
        public ObservableCollection<Address> Address { get; set; }

        public string AddressFullName { get => Address?.FirstOrDefault().FullName ?? "<Нет данных>"; }
        [Reactive]
        public ObservableCollection<RequisitesItem> Requisites { get; set; }

        [Reactive]
        public ReadOnlyObservableCollection<Gender> Genders { get; set; }

        [Reactive]
        public Gender SelectedGender { get; set; }

        [Reactive]
        public Constants.Operations SelectedOperation { get; set; }
        #endregion
    }
}