using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate
{
    public class Address : BaseEntity
    {
        public int IdEmployer { get; set; }
        public Employer Employer { get; set; }

        #region Поля
        public string Country { get; private set; }
        public int Postcode { get; private set; }
        /// <summary>
        /// Регион
        /// </summary>
        public string State { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        /// <summary>
        /// Населенный пункт
        /// </summary>
        public string Locality { get; private set; }
        /// <summary>
        /// Тип улицы
        /// </summary>
        public string StreetType { get; private set; }
        public string Street { get; private set; }
        /// <summary>
        /// Номер дома
        /// </summary>
        public int NumHome { get; private set; }
        /// <summary>
        /// Номер корпуса
        /// </summary>
        public int NumCase { get; private set; }
        /// <summary>
        /// Номер квартиры
        /// </summary>
        public int NumApartment { get; private set; } 
        #endregion

        public Address(string country, int postcode, string state, string district,string city,string locality,string streetType, string street,int numHome,int numCase, int numApartment)
        {
            Country = country;
            Postcode = postcode;
            State = state;
            District = district;
            City = city;
            Locality = locality;
            StreetType = streetType;
            Street = street;
            NumHome = numHome;
            NumCase = numCase;
            NumApartment = numApartment;
        }

        public Address()
        {
            // required by EF
        }

    }
}
