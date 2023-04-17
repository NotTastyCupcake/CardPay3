using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Specifications;
using Metcom.CardPay3.WebApplication.Interfaces;
using Metcom.CardPay3.WebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WebApplication.Services
{
    public class PersonViewModelService : IPersonViewModelService
    {
        private readonly ILogger<PersonViewModelService> _logger;
        private readonly IRepository<PersonItem> _itemRepository;
        private readonly IRepository<PersonOrganization> _organizationRepository;

        public PersonViewModelService(
            ILoggerFactory loggerFactory,
            IRepository<PersonItem> itemRepository,
            IRepository<PersonOrganization> organizationRepository)
        {
            _logger = loggerFactory.CreateLogger<PersonViewModelService>();
            _itemRepository = itemRepository;
            _organizationRepository = organizationRepository;
        }

        public async Task<PersonIndexViewModel> GetEmployers(int pageIndex, int itemsPage, int? organizationId)
        {
            _logger.LogInformation("GetEmployers called.");

            var filterSpecification = new PersonItemsSpecification(organizationId);
            var filterPaginatedSpecification = new PersonFilterPaginatedSpecification(pageIndex, itemsPage, organizationId);

            var itemsOnPage = await _itemRepository.ListAsync(filterPaginatedSpecification);
            var totalItems = await _itemRepository.CountAsync(filterSpecification);

            var viewModel = new PersonIndexViewModel()
            {
                Persons = itemsOnPage.Select(i => new PersonItemViewModel()
                {
                    Id = i.Id,
                    Name = i.FullName,
                    Organization = i.Organization.Name
                }).ToList(),
                Organization = await GetOrganizations(),
                OrganizationFilterApplied = organizationId ?? 0,
                PaginationInfo = new PaginationInfoViewModel()
                {
                    ActualPage = pageIndex,
                    ItemsPerPage = itemsOnPage.Count,
                    TotalItems = totalItems,
                    TotalPages = int.Parse(Math.Ceiling(((decimal)totalItems / itemsPage)).ToString())
                }

            };
            viewModel.PaginationInfo.Next = (viewModel.PaginationInfo.ActualPage == viewModel.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
            viewModel.PaginationInfo.Previous = (viewModel.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";

            return viewModel;
        }

        public Task<IEnumerable<SelectListItem>> GetGroups()
        {
            //TODO: Группы сотрудников
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SelectListItem>> GetOrganizations()
        {
            _logger.LogInformation("GetOrganizations called.");
            var organizations = await _organizationRepository.ListAsync();

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            foreach (PersonOrganization organization in organizations)
            {
                items.Add(new SelectListItem() { Value = organization.Id.ToString(), Text = organization.Name });
            }

            return items;
        }
    }
}
