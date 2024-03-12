using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes.RequisitiesCRUD;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Services
{
    public class RequisitiesViewModelService : IRequisitiesViewModelService
    {
        protected readonly ILogger<RequisitiesViewModelService> _logger;

        protected readonly IRepository<BankCardType> _typeRepository;
        protected readonly IRepository<BankCurrency> _currencyRepository;
        protected readonly IRepository<BankDivision> _divisionRepository;
        protected readonly IRepository<Status> _statusRepository;

        public RequisitiesViewModelService(
            IRepository<BankCardType> typeRepository,
            IRepository<BankCurrency> currencyRepository,
            IRepository<BankDivision> divisionRepository,
            IRepository<Status> statusRepository,
            ILogger<RequisitiesViewModelService> logger)
        {
            _typeRepository = typeRepository;
            _currencyRepository = currencyRepository;
            _divisionRepository = divisionRepository;
            _statusRepository = statusRepository;
            _logger = logger;
        }

        public async Task<ReadOnlyCollection<BankCurrency>> GetCurrencies()
        {
            return new ReadOnlyCollection<BankCurrency>(await _currencyRepository.ListAsync());
        }

        public async Task<ReadOnlyCollection<BankDivision>> GetDivisions()
        {
            return new ReadOnlyCollection<BankDivision>(await _divisionRepository.ListAsync());
        }

        public async Task<ReadOnlyCollection<Status>> GetStatuses()
        {
            return new ReadOnlyCollection<Status>(await _statusRepository.ListAsync());
        }

        public async Task<ReadOnlyCollection<BankCardType>> GetTypes()
        {
            return new ReadOnlyCollection<BankCardType>(await _typeRepository.ListAsync());
        }
    }
}
