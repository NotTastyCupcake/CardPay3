using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Metcom.CardPay3.ApplicationCore.Specifications;
using Metcom.CardPay3.ApplicationCore.Services;

namespace Metcom.CardPay3.UnitTests.ApplicationCore.Service.AccrualServiceTests
{
    public class AddItemToAccrual
    {
        private readonly int _organizationId = 1;
        private readonly int _accrualDay = 15;
        private readonly int _idAccrualType = 1;
        private readonly int _idOperationType = 1;

        private readonly Mock<IRepository<Accrual>> _mockAccrualRepo = new Mock<IRepository<Accrual>>();
        private Accrual Item;

        [SetUp]
        public void AddItemToAccrualSetUp()
        {
            Item = new Accrual(_organizationId, _accrualDay, _idAccrualType, _idOperationType);
        }

        [Test]
        public async Task InvokesAccrualRepositoryGetBySpecAsyncOnce()
        {
            Item.AddItem(1,It.IsAny<decimal>());
            _mockAccrualRepo.Setup(x => x.SingleOrDefaultAsync(It.IsAny<AccrualSpecification>(), default)).ReturnsAsync(Item);

            var accrualService = new AccrualService(_mockAccrualRepo.Object, null);

            await accrualService.AddItemToAccrual(Item.IdOrganization, 1, 15, 1.50m, 1, 1);
            _mockAccrualRepo.Verify(x => x.SingleOrDefaultAsync(It.IsAny<AccrualSpecification>(), default), Times.Once);
        }

        [Test]
        public async Task InvokesAccrualRepositoryUpdateAsyncOnce()
        {
            Item.AddItem(1, It.IsAny<decimal>());
            _mockAccrualRepo.Setup(x => x.SingleOrDefaultAsync(It.IsAny<AccrualSpecification>(), default)).ReturnsAsync(Item);

            var accrualService = new AccrualService(_mockAccrualRepo.Object, null);

            await accrualService.AddItemToAccrual(Item.IdOrganization, 1, 15, 1.50m, 1, 1);

            _mockAccrualRepo.Verify(x => x.UpdateAsync(Item, default), Times.Once);
        }
    }
}
