using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Services;
using Metcom.CardPay3.ApplicationCore.Specifications;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Metcom.CardPay3.UnitTests.ApplicationCore.Service.AccrualServiceTests
{
    public class AddItemToAccrual
    {
        private readonly int _organizationId = 1;
        private readonly DateTime _accrualDay = DateTime.Now;
        private readonly int _idAccrualType = 1;
        private readonly int _idOperationType = 1;

        private readonly Mock<IRepository<Accrual>> _mockAccrualRepo = new Mock<IRepository<Accrual>>();
        private Accrual Item;

        [SetUp]
        public void AddItemToAccrualSetUp()
        {
            // Arrange
            Item = new Accrual(_organizationId, _accrualDay, _idAccrualType, _idOperationType);
        }

        [Test]
        public async Task InvokesAccrualRepositoryGetBySpecAsyncOnce()
        {
            // Act
            Item.AddItem(1, It.IsAny<decimal>());
            _mockAccrualRepo.Setup(x => x.SingleOrDefaultAsync(It.IsAny<AccrualSpecification>(), default)).ReturnsAsync(Item);

            var accrualService = new AccrualService(_mockAccrualRepo.Object, null);

            await accrualService.AddItemToAccrual(Item.IdOrganization, 1, DateTime.Now, 1.50m, 1, 1);

            // Assert
            _mockAccrualRepo.Verify(x => x.SingleOrDefaultAsync(It.IsAny<AccrualSpecification>(), default), Times.Once);
        }

        [Test]
        public async Task InvokesAccrualRepositoryUpdateAsyncOnce()
        {
            Item.AddItem(1, It.IsAny<decimal>());
            _mockAccrualRepo.Setup(x => x.SingleOrDefaultAsync(It.IsAny<AccrualSpecification>(), default)).ReturnsAsync(Item);

            var accrualService = new AccrualService(_mockAccrualRepo.Object, null);

            await accrualService.AddItemToAccrual(Item.IdOrganization, 1, DateTime.Now, 1.50m, 1, 1);

            _mockAccrualRepo.Verify(x => x.UpdateAsync(Item, default), Times.Once);
        }
    }
}
