using NUnit.Framework;
using Moq;
using Metcom.CardPay3.ApplicationCore.Specifications;
using Metcom.CardPay3.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;

namespace Metcom.CardPay3.UnitTests.ApplicationCore.Service.AccrualServiceTests
{
    public class TransferAccrualAsync
    {
        private readonly int _organizationId = 1;
        private readonly int _accrualDay = 15;
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