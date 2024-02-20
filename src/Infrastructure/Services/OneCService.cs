using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.ApplicationCore.Interfaces.OneC;
using Metcom.CardPay3.Integration.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Services
{
    public class OneCService : IOneCService
    {
        private readonly IOneCSerializeService _serializeService;
        private readonly IOneCMappingService _mappingService;
        private readonly IAppLogger<OneCService> _logger;

        public OneCService(
            IOneCSerializeService serializeService,
            IOneCMappingService mappingService,
            IAppLogger<OneCService> logger)
        {
            _serializeService = serializeService;
            _mappingService = mappingService;
            _logger = logger;
        }

        public async Task OpenAccounts(Organization employee, string path)
        {
            var item = _mappingService.MapToOneC(employee, Integration.Models.СчетПК.ItemChoiceType.ОткрытиеСчетов);

            await _serializeService.SaveXML(item, path);
        }

        public async Task CloseAccounts(Organization employee, string path)
        {
            //TODO: Увольнение сотрудников
            throw new NotImplementedException();
        }

        public async Task SaveResultOpenAccounts(Stream stream)
        {
            //TODO: Обработка файла открытия счета
            throw new NotImplementedException();
        }
    }
}
