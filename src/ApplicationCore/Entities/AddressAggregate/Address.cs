using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate
{
    public class Address : BaseEntity
    {
        public int IdActualAddress { get; set; }
        public ActualAddressItem ActualAddress { get; set; }

        public int IdMailAddress { get; set; }
        public MailAddressItem MailAddress { get; set; }

        public int IdResidenceAddress { get; set; }
        public ResidenceAddressItem ResidenceAddress { get; set; }

        public Address()
        {
            // required by EF
        }

        public Address(int id, int idActual, int idMail, int idResidence)
        {
            Id = id;
            IdActualAddress = idActual;
            IdMailAddress = idMail;
            IdResidenceAddress = idResidence;
        }
        
    }
}
