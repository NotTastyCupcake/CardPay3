using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI.Validation.Helpers;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Splat;
using ReactiveUI.Fody.Helpers;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
using System.Reactive;
using System.Collections.ObjectModel;
using DynamicData;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using System.Windows.Forms;
using Castle.Core.Internal;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes
{
    public class CreateEmployeeViewModel : ReactiveValidationObject, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "CreateEmployee"; } }
        public IScreen HostScreen { get; protected set; }

        private readonly IRepository<Employee> _repository;
        private readonly IRepository<Gender> _genderRepo;
        private readonly IRepository<EmployeeType> _employeeType;

        private readonly ILogger<CreateEmployeeViewModel> _logger;
        private readonly IEmployeeViewModelService _employeViewModelService;
        private readonly IEmployeeBuilderSendObj _builder;

        public CreateEmployeeViewModel(IRepository<Employee> repository,
            IRepository<Gender> genderRepo,
            IRepository<EmployeeType> employeeType,
            ILogger<CreateEmployeeViewModel> logger,
            IEmployeeViewModelService viewModelService,
            IEmployeeBuilderSendObj builder,
            IScreen screen = null)
        {
            _repository = repository;
            _genderRepo = genderRepo;
            _employeeType = employeeType;

            _logger = logger;
            _employeViewModelService = viewModelService;
            _builder = builder;

            HostScreen = screen;

            this.ValidationRule(
                viewModel => viewModel.FirstName,
                item => !string.IsNullOrEmpty(item),
                "Имя должно быть заполнено обязательно");

            this.ValidationRule(
                viewModel => viewModel.LastName,
                item => !string.IsNullOrEmpty(item),
                "Фамилия должно быть заполнено обязательно");

            //this.ValidationRule(
            //    viewModel => viewModel.BirthdayDate,
            //    item => item != DateTime.MinValue,
            //    "Фамилия должно быть заполнено обязательно");

            Task.Run(() => Initialize());

            CreateEmployeeCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                await _builder.SetOrganization(Organization.Id);
                await _builder.SetEmployee(new Employee(LastName, 
                                                        FirstName, 
                                                        MiddleName,
                                                        BirthdayDate,
                                                        Nationality,
                                                        Resident,
                                                        PhoneNumber,
                                                        JobPhoneNumber,
                                                        Position,
                                                        DepartmentNum,
                                                        IdGender,
                                                        IdDocument,
                                                        IdOrganization));

                HostScreen.Router.NavigateBack.Execute();

            }, this.IsValid());

        }

        private async Task Initialize()
        {
            //Получаем выбранную организацию
            Organization = Locator.Current.GetService<HomeViewModel>().SelectedOrganization;
            
            Genders = new ObservableCollection<Gender>(await _genderRepo.ListAsync());
            EmployeeTypes = new ObservableCollection<EmployeeType>(await _employeeType.ListAsync());
        }

        #region Commands
        public ReactiveCommand<Unit, Unit> CreateEmployeeCommand { get; }
        #endregion

        #region Model
        [Reactive]
        public ICollection<Address> Addresses { get; set; }
        [Reactive]
        public DateTime BirthdayDate { get; set; }
        [Reactive]
        public string BonusNumber { get; set; }
        [Reactive]
        public string DepartmentNum { get; set; }
        [Reactive]
        public DocumentItem Document { get; set; }
        [Reactive]
        public int IdDocument { get; set; }
        [Reactive]
        public string EMail { get; set; }
        [Reactive]
        public string FirstName { get; set; }
        [Reactive]
        public string LastName { get; set; }
        [Reactive]
        public string MiddleName { get; set; }
        [Reactive]
        public Gender Gender { get; set; }
        [Reactive]
        public int IdGender { get; set; }
        [Reactive]
        public string JobPhoneNumber { get; set; }

        [Reactive]
        public string Nationality { get; set; }
        [Reactive]
        public Organization Organization { get; set; }
        [Reactive]
        public int IdOrganization { get; set; }
        [Reactive]
        public string PhoneNumber { get; set; }
        [Reactive]
        public string Position { get; set; }
        [Reactive]
        public ICollection<RequisitesItem> Requisites { get; set; }
        [Reactive]
        public bool Resident { get; set; }
        [Reactive]
        public EmployeeType Type { get; set; }
        [Reactive]
        public int IdType { get; set; }

        #endregion

        [Reactive]
        public ObservableCollection<Gender> Genders { get; set; }
        [Reactive]
        public ObservableCollection<EmployeeType> EmployeeTypes { get; set; }

    }
}
