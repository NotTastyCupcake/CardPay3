using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Specifications;
using Metcom.CardPay3.Infrastructure.Identity;
using Metcom.CardPay3.WebApplication.Interfaces;
using Metcom.CardPay3.WebApplication.ViewModels;
using Microsoft.AspNetCore.Identity;
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
        private readonly IRepository<Employe> _itemRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        
        public AccrualViewModelService(IRepository<Accrual> accrualRepository, 
            IRepository<Employe> itemRepository, UserManager<ApplicationUser> userManager)
        {
            _accrualRepository = accrualRepository;
            _itemRepository = itemRepository;
            _userManager = userManager;
        }

        public async Task<AccrualViewModel> GetOrCreateAsyncAccrualForUser(string userName)
        {

            var user = await _userManager.FindByNameAsync(userName);

            var accrualSpec = new AccrualSpecification(idOrganization: user.IdOrganization.ToString());
            var accrual = (await _accrualRepository.ListAsync(accrualSpec)).FirstOrDefault();

            if(accrual == null)
            {
                return await CreateAsyncAccrualForOrganization(user.IdOrganization, 
                    DateTime.Now.AddMonths(1), 
                    1, 
                    1);
            }
            return await CreateViewModelFromBasket(accrual);
        }

        private async Task<AccrualViewModel> CreateAsyncAccrualForOrganization(int organizationId,
            DateTime accrualDay,
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
                IdAccrualType = accrual.IdAccruaType,
                OrganizationId = accrual.IdOrganization,
                IdOperationType = accrual.IdOperationType
            };
        }

        private async Task<AccrualViewModel> CreateViewModelFromBasket(Accrual accrual)
        {
            var viewModel = new AccrualViewModel();
            viewModel.Id = accrual.Id;
            viewModel.AccrualDay = accrual.AccrualDay;
            viewModel.IdAccrualType = accrual.IdAccruaType;
            viewModel.OrganizationId = accrual.IdOrganization;
            viewModel.IdOperationType = accrual.IdOperationType;
            viewModel.Items = await GetAsyncAccrualItems(accrual.Items);
            return viewModel;
        }

        private async Task<List<AccrualItemViewModel>> GetAsyncAccrualItems(IReadOnlyCollection<AccrualItem> accrualItems)
        {
            var employerItemsSpecification = new EmployesSpecification(accrualItems.Select(b => b.IdEmployer).ToArray());
            var employerItems = await _itemRepository.ListAsync(employerItemsSpecification);

            var items = accrualItems.Select(accrualItem =>
            {
                var employerItem = employerItems.First(c => c.Id == accrualItem.IdEmployer);

                var accrualItemViewModel = new AccrualItemViewModel
                {
                    Id = accrualItem.Id,
                    FullName = employerItem.FullName,
                    Amount = accrualItem.Amount,
                    EmployerId = employerItem.Id,
                    Date = accrualItem.Date
                };
                return accrualItemViewModel;
            }).ToList();

            return items;
        }
    }
}
