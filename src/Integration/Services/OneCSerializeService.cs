using Metcom.CardPay3.Integration.Interfaces;
using Metcom.CardPay3.Integration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Metcom.CardPay3.ApplicationCore.Interfaces;

namespace Metcom.CardPay3.Integration.Services
{
    public class OneCSerializeService : IOneCSerializeService
    {
        private readonly IAppLogger<OneCSerializeService> _logger;
        public OneCSerializeService(IAppLogger<OneCSerializeService> logger)
        {
            _logger = logger;
        }

        public async Task SaveXML(СчетПК item, string path)
        {

            XmlSerializer serializeRequest = new XmlSerializer(typeof(СчетПК));
            StringWriter outStream = new StringWriter();

            XmlWriter xwriter = XmlWriter.Create(outStream);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

            try
            {
                serializeRequest.Serialize(xwriter, item, ns);
                XmlDocument document = new XmlDocument();
                document.LoadXml(outStream.ToString());
                document.Save(path);
            }
            catch (Exception ex)
            {
                _logger.LogError( "Произошла ошибка в модуле 'Интеграция с 1C': ошибка сериализации запроса", ex);
                throw;
            }
        }
    }
}
