using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces.Builder;
using Metcom.CardPay3.ApplicationCore.Services;
using Metcom.CardPay3.ApplicationCore.Services.Builder;
using Moq;
using System;
using System.Threading.Tasks;

namespace Metcom.CardPay3.UnitTests.ApplicationCore.Services.EmployeServiceTests
{
    public class CreateEmploye
    {

        private readonly Mock<IRepository<Employee>> _mockEmployeRepo = new Mock<IRepository<Employee>>();
        private readonly Mock<IAppLogger<EmployeeBuilder>> _mockLogger = new();
        private readonly Mock<IRepository<Gender>> _mockGenderRepo;
        private readonly Mock<IRepository<DocumentItem>> _mockDocumentRepo;
        private readonly Mock<IRepository<RequisitesItem>> _mockRequisitesRepo;
        private readonly Mock<IRepository<Address>> _mockAddressRepo;
        private readonly Mock<IRepository<Organization>> _mockOrganizationRepo;

        //private readonly string LastName = "Test LastName";
        //private readonly string FirstName = "Test FirstName";
        //private readonly string JobPhoneNum = "Test JobPhoneNum";
        //private readonly string MiddleName = "Test MiddleName";
        //private readonly string PhoneNum = "Test PhoneNum";
        //private readonly string Position = "Test Position";
        //private readonly string DepartmentNum = "Test DepartmentNum";
        private readonly int _idGender = 0;
        private readonly int _idTypeDocument = 0;
        //private readonly DateTime DataIssuedDocument = DateTime.Now;
        //private readonly string IssuedByDocument = "Test IssuedByDocument";
        //private readonly string SubdivisionCodeDocument = "Test SubdivisionCodeDocument";
        private readonly int _organizationId = 0;

        //[Test]
        public async Task InvokesEmployeeRepositoryGetBySpecAsyncOnce()
        {
            //TODO: Создать юнит тест
            _mockEmployeRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>(), default)).ReturnsAsync(new Employee());

            var employeeBuilder = new EmployeeBuilder(_mockEmployeRepo.Object, 
                                                    _mockGenderRepo.Object, 
                                                    _mockDocumentRepo.Object, 
                                                    _mockRequisitesRepo.Object, 
                                                    _mockAddressRepo.Object, 
                                                    _mockOrganizationRepo.Object,
                                                    _mockLogger.Object);

            //TODO: Тест создания сотрудника
            //var employe = await employeBuilder.SetGender();

            //employe = await employe.SetDocument(_idTypeDocument,
            //                                    It.IsAny<DateTime>(),
            //                                    It.IsAny<string>(),
            //                                    It.IsAny<string>());

            //employe = await employe.SetOrganization(_organizationId);
        }
    }
}
