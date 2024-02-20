using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Specifications;
using Metcom.CardPay3.ApplicationCore.Specifications.Employees;
using Metcom.CardPay3.Infrastructure.Identity;
using Metcom.CardPay3.WebApplication.Interfaces;
using Metcom.CardPay3.WebApplication.ViewModels;
using Metcom.CardPay3.WebApplication.ViewModels.Employes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WebApplication.Services
{
    public class EmployerViewModelService : IEmployerViewModelService
    {
        private readonly ILogger<EmployerViewModelService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IRepository<Employee> _itemRepository;
        private readonly IRepository<Organization> _organizationRepository;
        private readonly IRepository<Gender> _genderRepository;
        private readonly IRepository<DocumentType> _documentTypeRepository;

        public EmployerViewModelService(
            ILoggerFactory loggerFactory,
            UserManager<ApplicationUser> userManager,
            IRepository<Employee> itemRepository,
            IRepository<Organization> organizationRepository,
            IRepository<Gender> genderRepository,
            IRepository<DocumentType> documentTypeRepository)
        {

            _logger = loggerFactory.CreateLogger<EmployerViewModelService>();
            _userManager = userManager;
            _itemRepository = itemRepository;
            _organizationRepository = organizationRepository;
            _genderRepository = genderRepository;
            _documentTypeRepository = documentTypeRepository;
        }

        public async Task<EmployeIndexViewModel> GetEmployers(int pageIndex, int itemsPage, int? organizationId)
        {
            _logger.LogInformation("GetEmployers called.");

            var filterSpecification = new EmployesSpecification(organizationId);
            var filterPaginatedSpecification = new EmployerFilterPaginatedSpecification(itemsPage * pageIndex, itemsPage, organizationId);

            var itemsOnPage = await _itemRepository.ListAsync(filterPaginatedSpecification);
            var totalItems = await _itemRepository.CountAsync(filterSpecification);

            var viewModel = new EmployeIndexViewModel()
            {
                Employers = itemsOnPage.Select(i => new EmployerItemViewModel()
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
            viewModel.PaginationInfo.Next = (viewModel.PaginationInfo.ActualPage == viewModel.PaginationInfo.TotalPages - 1) ? "disabled" : "";
            viewModel.PaginationInfo.Previous = (viewModel.PaginationInfo.ActualPage == 0) ? "disabled" : "";

            return viewModel;
        }

        public async Task<EmployerViewModel> GetEmploye(int idEmploye)
        {
            _logger.LogInformation("GetEmploye called.");

            var item = await _itemRepository.GetByIdAsync(idEmploye);

            var viewModel = new EmployerViewModel()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                MiddleName = item.MiddleName,
                LastName = item.LastName,
                DepartmentNum = item.DepartmentNum,
                Gender = new EmployeGenderViewModel() 
                    { 
                        GenderName = item.Gender.GenderName,
                        Id = item.Gender.Id
                    },
                JobPhoneNumber = item.JobPhoneNumber,
                NameOrganization = item.Organization.Name,
                PhoneNumber = item.PhoneNumber,
                Position = item.Position
            };

            return viewModel;
        }

        public async Task<IEnumerable<SelectListItem>> GetOrganizations()
        {
            _logger.LogInformation("GetOrganizations called.");
            var organizations = await _organizationRepository.ListAsync();

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            foreach (var organization in organizations)
            {
                items.Add(new SelectListItem() { Value = organization.Id.ToString(), Text = organization.Name });
            }

            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetGenders()
        {
            _logger.LogInformation("GetGenders called.");
            var genders = await _genderRepository.ListAsync();

            var items = new List<SelectListItem>();

            foreach (var gender in genders)
            {
                items.Add(new SelectListItem() { Value = gender.Id.ToString(), Text = gender.GenderName });
            }

            return items;
        }
        public async Task<IEnumerable<SelectListItem>> GetDocumentTypes()
        {
            _logger.LogInformation("GetDocumentType called.");
            var types = await _documentTypeRepository.ListAsync();

            var items = new List<SelectListItem>();
            foreach (var type in types)
            {
                items.Add(new SelectListItem() { Value = type.Id.ToString(), Text = type.Name });
            }

            return items;
        }

    }
}
