using Metcom.CardPay3.ApplicationCore.Entities;
using NUnit.Framework;
using System;

namespace Metcom.CardPay3.UnitTests.ApplicationCore.Entities.EmployerItemTests
{
    public class UpdateContactDetails
    {
        private Employe _testItem;

        private string _validLastName = "TestLastName";
        private string _validFirstName = "TestFirstName";
        private string _validMiddleName = "TestMiddleName";
        private int _validGenderId = 1;
        private int _validDocumentId = 1;
        private string _validPhoneNumber = "8888";
        private string _validJobPhoneNumber = "1111";
        private string _validPosition = "TestPosition";
        private string _validDepartmentNum = "TestDepartamentNum";
        private int _validIdRequest = 1;
        private int _validIdOrganization = 1;

        [SetUp]
        public void UpdateContactDetailsSetUp()
        {
            _testItem = new Employe(
                _validLastName, _validFirstName, _validMiddleName,
                _validPhoneNumber, _validJobPhoneNumber, _validPosition, _validDepartmentNum,
                _validGenderId, _validDocumentId, _validIdRequest);
        }

        [TestCase("", "", "", "")]
        [TestCase("Test", "", "", "")]
        [TestCase("", "Test", "", "")]
        [TestCase("", "", "Test", "")]
        [TestCase("", "", "", "Test")]
        [TestCase("Test", "Test", "", "")]
        [TestCase("", "Test", "Test", "")]
        [TestCase("", "", "Test", "Test")]
        [TestCase("Test", "", "", "Test")]
        public void ThrowsArgumentExceptionGivenEmptyName(string phoneNum, string jobPhone, string position, string departmentNum)
        {
            Assert.Throws<ArgumentException>(() => _testItem.UpdateContactDetails(phoneNum, jobPhone, position, departmentNum));
        }

        [TestCase(null, null, null, null)]
        [TestCase("Test", null, null, null)]
        [TestCase(null, "Test", null, null)]
        [TestCase(null, null, "Test", null)]
        [TestCase(null, null, null, "Test")]
        [TestCase("Test", "Test", null, null)]
        [TestCase(null, "Test", "Test", null)]
        [TestCase(null, null, "Test", "Test")]
        [TestCase("Test", null, null, "Test")]
        public void ThrowsArgumentNullExceptionGivenEmptyName(string phoneNum, string jobPhone, string position, string departmentNum)
        {
            Assert.Throws<ArgumentNullException>(() => _testItem.UpdateContactDetails(phoneNum, jobPhone, position, departmentNum));
        }
    }
}
