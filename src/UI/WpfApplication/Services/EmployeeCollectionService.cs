using DynamicData;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Specifications;
using Metcom.CardPay3.ApplicationCore.Specifications.Employees;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Metcom.CardPay3.WpfApplication.ViewModels;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using Splat;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Services
{
    public class EmployeeCollectionService : ReactiveObject, IEmployeeCollectionService
    {
        private readonly ILogger<EmployeeCollectionService> _logger;
        private readonly IRepository<Employee> _repository;

        public EmployeeCollectionService(
            ILogger<EmployeeCollectionService> logger,
            IRepository<Employee> repository)
        {
            _logger = logger;
            _repository = repository;

            //TODO: Обновление списка сотрудников за определенный интервал
            // Load the initial data from the database

            //// Subscribe to the changes in the database every 5 seconds
            //var obs = Observable.Interval(TimeSpan.FromSeconds(5), RxApp.TaskpoolScheduler)
            //    .SelectMany(_ => _repository.ListAsync()))
            //    .Where(employees => !employees.SequenceEqual(All.Items));

            //obs.Subscribe(employees =>
            //{
            //    // Update the source cache with the latest data
            //    All.Clear();
            //    All.AddOrUpdate(employees);
            //});
        }

        public async Task LoadOrUpdateEmployeesCollection()
        {

            var spec = new EmployesSpecification(organizationId: Locator.Current.GetService<ShallViewModel>().SelectedOrganization.Id);

            var employes = await _repository.ListAsync(spec);

            All.Clear();
            All.AddOrUpdate(employes);

        }



        public SourceCache<Employee, int> All { get; } = new SourceCache<Employee, int>(e => e.Id);
    }
}
