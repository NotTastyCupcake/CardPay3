using Ardalis.GuardClauses;
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

        public async Task<Accrual> AddItemToAccrual(string idOrganization ,int personId, int accrualDay, decimal amount, int idAccrualType, int idOperationType)
        {

            var accrualSpec = new AccrualSpecification(idOrganization);
            var accrual = await _accrualRepository.SingleOrDefaultAsync(accrualSpec);

            if(accrual == null)
            {
                accrual = new Accrual(idOrganization, accrualDay, idAccrualType, idOperationType);
                await _accrualRepository.AddAsync(accrual);
            }
            accrual.AddItem(personId, amount);

            await _accrualRepository.UpdateAsync(accrual);
            return accrual;
        }

        public async Task<Accrual> DeleteItem(int accrualId, int personId)
        {

            var accrual = await _accrualRepository.GetByIdAsync(accrualId);

            if (accrual == null) { return null; }

            accrual.RemovePerson(personId);

            await _accrualRepository.UpdateAsync(accrual);
            return accrual;

        }

        public async Task DeleteAccrual(int accrualId)
        {
            var accrual = await _accrualRepository.GetByIdAsync(accrualId);

            if (_logger != null)
            {
                _logger.LogWarning($"Deleting acccrual by ID:{accrualId}");
            }

            await _accrualRepository.DeleteAsync(accrual);
        }

        //TODO: Создать тригер расписания Quartz
        public async Task TransferAccrualAsync(string oldIdOrganization, string newIdOrganization)
        {
            var oldAccrualSpec = new AccrualSpecification(oldIdOrganization);
            var accrual = await _accrualRepository.SingleOrDefaultAsync(oldAccrualSpec);

            if(accrual == null) { return; }

            if(_logger != null) 
            {
                _logger.LogInformation($"Updating organization of accrual ID:{accrual.Id} to {newIdOrganization}");
            }

            accrual.SetNewOrganizationId(newIdOrganization);

            await _accrualRepository.UpdateAsync(accrual);
        }

        public async Task<Accrual> SetAmounts(int accrualId, Dictionary<string, decimal> amounts)
        {
            Guard.Against.Null(amounts, nameof(amounts));
            var accrual = await _accrualRepository.GetByIdAsync(accrualId);
            Guard.Against.Null(accrual, nameof(accrual));

            foreach(var item in accrual.Items)
            {
                if(amounts.TryGetValue(item.Id.ToString(), out var amount))
                {
                    if (_logger != null) _logger.LogInformation($"Updating amount of item ID:{item.Id} to {amount}.");
                    item.SetAmount(amount);
                }
            }
            await _accrualRepository.UpdateAsync(accrual);
            return accrual;
        }

    }
}
