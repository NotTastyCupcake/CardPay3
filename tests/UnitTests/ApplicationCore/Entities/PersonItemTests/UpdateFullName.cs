using Metcom.CardPay3.ApplicationCore.Entities;
using NUnit.Framework;
using System;

namespace Metcom.CardPay3.UnitTests.ApplicationCore.Entities.EmployerItemTests
{
    public class UpdateFullName
    {
        private Employer _testItem;

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

        [SetUp]
        public void UpdateFullNameSetUp()
        {
            _testItem = new Employer(
                _validLastName, _validFirstName, _validMiddleName,
                _validPhoneNumber, _validJobPhoneNumber, _validPosition, _validDepartmentNum,
                _validGenderId, _validDocumentId, _validIdRequest);
        }

        [TestCase("", "", "")]
        [TestCase("Test", "", "")]
        [TestCase("Test", "Test", "")]
        [TestCase("", "Test", "Test")]
        [TestCase("", "", "Test")]
        [TestCase("Test", "", "Test")]
        public void ThrowsArgumentExceptionGivenEmptyName(string lastName, string firstName, string middleName)
        {
            Assert.Throws<ArgumentException>(() => _testItem.UpdateFullName(lastName, firstName, middleName));
        }

        [TestCase(null, null, null)]
        [TestCase("Test", null, null)]
        [TestCase("Test", "Test", null)]
        [TestCase(null, "Test", "Test")]
        [TestCase(null, null, "Test")]
        [TestCase("Test", null, "Test")]
        public void ThrowsArgumentNullExceptionGivenEmptyName(string lastName, string firstName, string middleName)
        {
            Assert.Throws<ArgumentNullException>(() => _testItem.UpdateFullName(lastName, firstName, middleName));
        }
    }
}
