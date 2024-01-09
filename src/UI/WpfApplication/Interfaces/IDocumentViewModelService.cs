using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Interfaces
{
    public interface IDocumentViewModelService
    {
        public Task<ReadOnlyObservableCollection<DocumentType>> GetDocumentTypes();
    }
}
