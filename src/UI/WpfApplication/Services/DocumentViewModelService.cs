using Castle.Core.Logging;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Services
{
    public class DocumentViewModelService : ReactiveObject, IDocumentViewModelService
    {
        private readonly IRepository<DocumentType> _typeRepository;
        private readonly ILogger<DocumentViewModelService> _logger;

        public DocumentViewModelService(
            IRepository<DocumentType> typeRepository, 
            ILogger<DocumentViewModelService> logger)
        {
            _typeRepository = typeRepository;
            _logger = logger;
        }

        public async Task<ReadOnlyObservableCollection<DocumentType>> GetDocumentTypes()
        {
            _logger.LogInformation("GetDocumentTypes called.");

            var types = await _typeRepository.ListAsync();

            return new ReadOnlyObservableCollection<DocumentType>(new ObservableCollection<DocumentType>(types));
        }
    }
}
