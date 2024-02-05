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
            IEmployeeBuilder builder,
            IRepository<Employee> repository,
            IScreen screen = null) : base(genderRepo, employeeType, logger, viewModelService, builder)
        {
            _repository = repository;
            HostScreen = screen;

            #region Commands

            EditEmployeeCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                HostScreen.Router.NavigateBack.Execute();

            }, this.IsValid);

            EditDocumentCommand = ReactiveCommand.Create(delegate ()
            {
                var vm = Locator.Current.GetService<CreateDocumentViewModel>();
                HostScreen.Router.Navigate.Execute(vm);
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
        }

        public Employee Employee { get; set; }
        public int Id { get; set; }

    }
}
