using DynamicData;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Services
{
    public class EmployeCollectionService : ReactiveObject, IEmployeCollectionService
    {
        private readonly ILogger<EmployeCollectionService> _logger;
        private readonly IRepository<Employe> _repository;

        public EmployeCollectionService(
            ILogger<EmployeCollectionService> logger,
            IRepository<Employe> repository)
        {
            _logger = logger;
            _repository = repository;

            // Load the initial data from the database
            LoadEmployees();

            // Subscribe to the changes in the database every 5 seconds
            Observable.Interval(TimeSpan.FromSeconds(5), RxApp.TaskpoolScheduler)
                .SelectMany(_ => _repository.ListAsync())
                .Subscribe(employees =>
                {
                    // Update the source cache with the latest data
                    All.Edit(innerList =>
                    {
                        innerList.Clear();
                        innerList.AddOrUpdate(employees);
                    });
                });

        }

        private void LoadEmployees()
        {
            var employes = Task.Run(() => _repository.ListAsync()).Result;
            All.AddOrUpdate(employes);
        }

        public SourceCache<Employe, int> All { get; } = new SourceCache<Employe, int>(e => e.Id);
    }
}
