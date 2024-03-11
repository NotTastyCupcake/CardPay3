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

        public async Task OpenAccounts(Organization organization, ICollection<Employee> employees, string path)
        {
            var item = _mappingService.MapToOneC(organization, employees, Integration.Models.СчетПК.ItemChoiceType.ОткрытиеСчетов);

            await _serializeService.SaveXML(item, path);
        }

        public async Task CloseAccounts(Organization organization, ICollection<Employee> employees, string path)
        {
            var item = _mappingService.MapToOneC(organization, employees, Integration.Models.СчетПК.ItemChoiceType.СписокУвольнений);

            await _serializeService.SaveXML(item, path);
        }

        public async Task SaveResultOpenAccounts(Stream stream)
        {
            //TODO: Обработка файла открытия счета
            //_mappingService.MapFromOneC()
            throw new NotImplementedException();
        }
    }
}
