using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Specifications;
using Metcom.CardPay3.WebApplication.Interfaces;
using Metcom.CardPay3.WebApplication.Pages.Accrual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WebApplication.Services
{
    public class AccrualViewModelService : IAccrualViewModelService
    {
        private readonly IRepository<Accrual> _accrualRepository;
        public readonly IRepository<PersonItem> _itemRepository;

        public AccrualViewModelService(IRepository<Accrual> accrualRepository, IRepository<PersonItem> itemRepository)
        {
            _accrualRepository = accrualRepository;
            _itemRepository = itemRepository;
        }

        public async Task<AccrualViewModel> GetOrCreateAccrualForUser(string organizationId, int accrualDay,
            int accrualType,
            int accrualOperationType)
        {
            var accrualSpec = new AccrualSpecification(organizationId);
            var accrual = (await _accrualRepository.ListAsync(accrualSpec)).FirstOrDefault();

            if(accrual == null)
            {
                return await CreateAccrualForOrganization(organizationId, accrualDay, accrualType, accrualOperationType);
            }
            return await CreateViewModelFromBasket(accrual);
        }

        private async Task<AccrualViewModel> CreateAccrualForOrganization(string organizationId,
            int accrualDay,
            int accrualType,
            int accrualOperationType)
        {
            var accrual = new Accrual(organizationId, accrualDay, accrualType, accrualOperationType);
            await _accrualRepository.AddAsync(accrual);

            return new AccrualViewModel()
            {
                Id = accrual.Id,
                Items = new List<AccrualItemViewModel>(),
                AccrualDay = accrual.AccrualDay,
                IdType = accrual.IdType,
                OrganizationId = accrual.OrganizationId
            };
        }

        private async Task<AccrualViewModel> CreateViewModelFromBasket(Accrual accrual)
        {
            var viewModel = new AccrualViewModel();
            viewModel.Id = accrual.Id;
            viewModel.AccrualDay = accrual.AccrualDay;
            viewModel.IdType = accrual.IdType;
            viewModel.OrganizationId = accrual.OrganizationId;
            viewModel.Items = await GetAccrualItems(accrual.Items);
            return viewModel;
        }

        private async Task<List<AccrualItemViewModel>> GetAccrualItems(IReadOnlyCollection<AccrualItem> accrualItems)
        {
            var personItemsSpecification = new PersonItemsSpecification(accrualItems.Select(b => b.PersonId).ToArray());
            var personItems = await _itemRepository.ListAsync(personItemsSpecification);

            var items = accrualItems.Select(accrualItem =>
            {
                var personItem = personItems.First(c => c.Id == accrualItem.PersonId);

                var accrualItemViewModel = new AccrualItemViewModel
                {
                    Id = accrualItem.Id,
                    FullName = personItem.FullName,
                    Amouth = accrualItem.Amount,
                    PersonId = personItem.Id,
                    Date = accrualItem.Date
                };
                return accrualItemViewModel;
            }).ToList();

            return items;
        }
    }
}
