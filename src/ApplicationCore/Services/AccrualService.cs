using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Services
{
    public class AccrualService : IAccrualService
    {
        private readonly IRepository<Accrual> _accrualRepository;
        private readonly ILogger _logger;

        public AccrualService(IRepository<Accrual> accrualRepository, ILogger logger)
        {
            _accrualRepository = accrualRepository;
            _logger = logger;
        }

        public async Task<Accrual> AddItemToBasket(string idOrganization ,int personId, int payDay, decimal amount, int idTypePay, int idOperationType)
        {
            var accrualSpec = new AccrualSpecification(idOrganization);
            var accrual = await _accrualRepository.GetBySpecAsync(accrualSpec);

            if(accrual == null)
            {
                accrual = new Accrual(idOrganization);
                await _accrualRepository.AddAsync(accrual);
            }
            accrual.AddItem(personId, payDay, amount, idTypePay, idOperationType);

            await _accrualRepository.UpdateAsync(accrual);
            return accrual;
        }

        public Task<Accrual> DeleteItem(int personId)
        {
            throw new NotImplementedException();
        }

        public Task TransferAccrualAsync(string anonymousId, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
