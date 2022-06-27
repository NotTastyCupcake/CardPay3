using Metcom.CardPay3.ApplicationCore.Entities.PersonAggregate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.UnitTests.ApplicationCore.Entities.PersonItemTests
{
    public class UpdateNameCard
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
        public void UpdateNameCardSetUp()
        {
            _testItem = new PersonItem(_validId,_validLastName,_validFirstName, _validMiddleName, _validLatinFirstName, _validLatinLastName, _validGenderId, _validDocumentId);
        }

        [TestCase("", "")]
        [TestCase("Test", "")]
        [TestCase("", "Test")]
        public void ThrowsArgumentExceptionGivenEmptyName(string lastName, string firstName)
        {
            Assert.Throws<ArgumentException>(() => _testItem.UpdateNameCard(lastName, firstName));
        }

        [TestCase(null, null)]
        [TestCase("Test", null)]
        [TestCase(null, "Test")]
        public void ThrowsArgumentNullExceptionGivenEmptyName(string lastName, string firstName)
        {
            Assert.Throws<ArgumentNullException>(() => _testItem.UpdateNameCard(lastName, firstName));
        }
    }
}
