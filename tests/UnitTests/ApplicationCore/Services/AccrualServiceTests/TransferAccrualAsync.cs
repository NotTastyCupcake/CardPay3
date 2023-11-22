using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Moq;
using NUnit.Framework;
using System;

namespace Metcom.CardPay3.UnitTests.ApplicationCore.Service.AccrualServiceTests
{
    public class TransferAccrualAsync
    {
        private readonly int _organizationId = 1;
        private readonly DateTime _accrualDay = DateTime.Now;
        private readonly int _idAccrualType = 1;
        private readonly int _idOperationType = 1;

        private readonly Mock<IRepository<Accrual>> _mockAccrualRepo = new Mock<IRepository<Accrual>>();
        private Accrual Item;

        [SetUp]
        public void TransferAccrualAsyncSetUp()
        {
            Item = new Accrual(_organizationId, _accrualDay, _idAccrualType, _idOperationType);
        }
    }
}