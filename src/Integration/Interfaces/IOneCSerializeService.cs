using Metcom.CardPay3.Integration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Integration.Interfaces
{
    public interface IOneCSerializeService
    {
        public Task SaveXML(СчетПК item, string path);
    }
}
