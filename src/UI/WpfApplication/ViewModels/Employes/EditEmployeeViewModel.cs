using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using Splat;
using Metcom.CardPay3.Infrastructure.Data;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes.DocumentCRUD;
using System.Reactive.Linq;

namespace Metcom.CardPay3.WpfApplication.ViewModels.Employes
{
    public class EditEmployeeViewModel : EmployeeViewModel, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "EditEmployee"; } }
        public IScreen HostScreen { get; protected set; }

        private readonly IRepository<Employee> _repository;

        public EditEmployeeViewModel(
            IRepository<Gender> genderRepo,
            IRepository<EmployeeType> employeeType,
            ILogger<CreateEmployeeViewModel> logger,
            IEmployeeViewModelService viewModelService,
            IEmployeeCollectionService collectionService,
            IEmployeeBuilder builder,
            IRepository<Employee> repository,
            IScreen screen = null) : base(genderRepo, employeeType, logger, viewModelService, builder)
        {
            _repository = repository;
            HostScreen = screen;

            #region Commands

            EditEmployeeCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                SetEmployee();
                await repository.UpdateAsync(Employee);
                await repository.SaveChangesAsync();
                await HostScreen.Router.NavigateBack.Execute();
                await collectionService.LoadOrUpdateEmployeesCollection();

            }, this.IsValid);

            EditDocumentCommand = ReactiveCommand.CreateFromTask(async delegate ()
            {
                var vm = Locator.Current.GetService<CreateDocumentViewModel>();
                await vm.InitializeAsync();
                await HostScreen.Router.Navigate.Execute(vm);
                vm.WhenAnyValue(vm => vm.Document).Subscribe(_ => Document = _);
            });

            #endregion
        }


        #region Commands
        public ReactiveCommand<Unit, Unit> EditEmployeeCommand { get; }
        public ReactiveCommand<Unit, Unit> EditDocumentCommand { get; }
        #endregion

        public void GetEmployeeToEdit(Employee employee)
        {
            LastName = employee.LastName;
            FirstName = employee.FirstName;
            MiddleName = employee.MiddleName;
            BirthdayDate = employee.BirthdayDate;
            BirthdayDateSelected = employee.BirthdayDate;
            ResidentSelected = employee.Resident;
            Resident = employee.Resident;
            Nationality = employee.Nationality;
            PhoneNumber = employee.PhoneNumber;
            JobPhoneNumber = employee.JobPhoneNumber;
            Position = employee.Position;
            DepartmentNum = employee.DepartmentNum;
            Gender = employee.Gender;
            IdGender = employee.IdGender;
            Document = employee.Document;
            IdDocument = employee.IdDocument;
            Organization = employee.Organization;
            IdOrganization = employee.IdOrganization;

            Employee = employee;
        }

        private void SetEmployee()
        {
            Employee.LastName = LastName;
            Employee.FirstName = FirstName;
            Employee.MiddleName = MiddleName;
            Employee.BirthdayDate = BirthdayDate;
            Employee.Resident = Resident;
            Employee.Nationality = Nationality;
            Employee.PhoneNumber = PhoneNumber;
            Employee.JobPhoneNumber = JobPhoneNumber;
            Employee.Position = Position;
            Employee.DepartmentNum = DepartmentNum;
            Employee.Gender = Gender;
            Employee.IdGender = IdGender;
            Employee.Document = Document;
            Employee.IdDocument = IdDocument;
            Employee.Organization = Organization;
            Employee.IdOrganization = IdOrganization;
        }

        public Employee Employee { get; set; }

    }
}
