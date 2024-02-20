using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.Integration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Integration.Interfaces
{
    public interface IOneCMappingService
    {
        public СчетПК MapToOneC(Organization organization, СчетПК.ItemChoiceType type);
        public Employee MapFromOneC(СчетПК item);
    }
}
