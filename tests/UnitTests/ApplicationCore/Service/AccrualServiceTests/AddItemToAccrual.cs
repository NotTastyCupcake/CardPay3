using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using NUnit.Framework;
using Metcom.CardPay3.ApplicationCore.Specifications;
using Metcom.CardPay3.ApplicationCore.Services;

namespace Metcom.CardPay3.UnitTests.ApplicationCore.Service.AccrualServiceTests
{
    public class AddItemToAccrual
    {
        private readonly string _organizationId = "Test Organization";
        private readonly Mock<IRepository<Accrual>> _mockAccrualRepo = new Mock<IRepository<Accrual>>();
        private Accrual Item;

        [SetUp]
        public void AddItemToAccrualSetUp()
        {
            Item = new Accrual(_organizationId);
        }

        [Test]
        public async Task InvokesAccrualRepositoryGetBySpecAsyncOnce()
        {
            Item.AddItem(1, It.IsAny<int>(), It.IsAny<decimal>(), It.IsAny<int>(), It.IsAny<int>());
            _mockAccrualRepo.Setup(x => x.SingleOrDefaultAsync(It.IsAny<AccrualSpecification>(), default)).ReturnsAsync(Item);

            var accrualService = new AccrualService(_mockAccrualRepo.Object, null);

            await accrualService.AddItemToAccrual(Item.OrganizationId, 1, 15, 1.50m, 1, 1);
            _mockAccrualRepo.Verify(x => x.SingleOrDefaultAsync(It.IsAny<AccrualSpecification>(), default), Times.Once);
        }

        [Test]
        public async Task InvokesAccrualRepositoryUpdateAsyncOnce()
        {
            Item.AddItem(1, It.IsAny<int>(), It.IsAny<decimal>(), It.IsAny<int>(), It.IsAny<int>());
            _mockAccrualRepo.Setup(x => x.SingleOrDefaultAsync(It.IsAny<AccrualSpecification>(), default)).ReturnsAsync(Item);

            var accrualService = new AccrualService(_mockAccrualRepo.Object, null);

            await accrualService.AddItemToAccrual(Item.OrganizationId, 1, 15, 1.50m, 1, 1);

            _mockAccrualRepo.Verify(x => x.UpdateAsync(Item, default), Times.Once);
        }
    }
}
