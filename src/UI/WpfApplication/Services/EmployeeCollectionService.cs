using DynamicData;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Specifications;
using Metcom.CardPay3.ApplicationCore.Specifications.Employees;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Metcom.CardPay3.WpfApplication.Models;
using Metcom.CardPay3.WpfApplication.ViewModels;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Services
{
    public class EmployeeCollectionService : ReactiveObject, IEmployeeCollectionService
    {
        private readonly ILogger<EmployeeCollectionService> _logger;
        private readonly IRepository<Employee> _repository;
        private readonly IRepository<Status> _statusRepo;

        public EmployeeCollectionService(
            ILogger<EmployeeCollectionService> logger,
            IRepository<Employee> repository,
            IRepository<Status> statusRepo)
        {
            _logger = logger;
            _repository = repository;
            _statusRepo = statusRepo;
        }

        public async Task LoadOrUpdateEmployeesCollection()
        {

            var spec = new EmployesSpecification(organizationId: Locator.Current.GetService<ShallViewModel>().SelectedOrganization.Id);

            var employes = await _repository.ListAsync(spec);

            All.Clear();
            All.AddOrUpdate(employes.Select(e => new SelectableItemWrapper<Employee>() { Item = e, IsSelected = false }));

        }

        public async Task<ReadOnlyCollection<Status>> GetStatusesCollection()
        {
            return new ReadOnlyCollection<Status>(await _statusRepo.ListAsync());
        }

        public SourceCache<SelectableItemWrapper<Employee>, int> All { get; } = new SourceCache<SelectableItemWrapper<Employee>, int>(e => e.Item.Id);
    }
}
