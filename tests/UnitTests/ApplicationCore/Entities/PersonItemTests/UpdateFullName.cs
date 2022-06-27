using Metcom.CardPay3.ApplicationCore.Entities.PersonAggregate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.UnitTests.ApplicationCore.Entities.PersonItemTests
{
    public class UpdateFullName
    {
        private PersonItem _testItem;

        private int _validId = 1;
        private string _validLastName = "TestLastName";
        private string _validFirstName = "TestFirstName";
        private string _validMiddleName = "TestMiddleName";
        private string _validLatinFirstName = "TestFirstLatinName";
        private string _validLatinLastName = "TestLastLatinName";
        private int _validGenderId = 1;
        private int _validDocumentId = 1;

        [SetUp]
        public void UpdateFullNameSetUp()
        {
            _testItem = new PersonItem(_validId,_validLastName,_validFirstName, _validMiddleName, _validLatinFirstName, _validLatinLastName, _validGenderId, _validDocumentId);
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
