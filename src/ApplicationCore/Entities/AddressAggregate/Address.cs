using System;

namespace Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate
{
    public class Address : BaseEntity, IAddress
    {
#nullable enable
        public int? IdEmployee { get; set; }
        public virtual Employee? Employee { get; set; }
#nullable disable

        #region Поля

        public string FullName => $"{Postcode}, {Country.Name}, {State.Name}, {City.Name},{StreetType} {Street.Name},д. {NumHome}";
        /// <summary>
        /// Индекс
        /// </summary>
        public int Postcode { get; set; }

        public int IdCountry { get; set; }
        public virtual Geographic Country { get; set; }

        public int IdState { get; set; }
        /// <summary>
        /// Регион
        /// </summary>
        public virtual Geographic State { get; set; }

        /// <summary>
        /// Район
        /// </summary>
        public string District { get; set; }

        public int IdCity { get; set; }
        public virtual Geographic City { get; set; }


        public int IdLocality { get; set; }
        /// <summary>
        /// Населенный пункт
        /// </summary>
        public virtual Geographic Locality { get; set; }

        /// <summary>
        /// Тип улицы
        /// </summary>
        public string StreetType { get; set; }

        public int IdStreet { get; set; }
        public virtual Geographic Street { get; set; }

        /// <summary>
        /// Номер дома
        /// </summary>
        public int NumHome { get; set; }
        /// <summary>
        /// Номер корпуса
        /// </summary>
        public int NumCase { get; set; }
        /// <summary>
        /// Номер квартиры
        /// </summary>
        public int NumApartment { get; set; }
        #endregion

        public Address(int idCountry, int postcode, int idState, string district, int idCity, int idLocality, string streetType, int idStreet, int numHome, int numCase, int numApartment)
        {
            IdCountry = idCountry;
            Postcode = postcode;
            IdState = idState;
            District = district;
            IdCity = idCity;
            IdLocality = idLocality;
            StreetType = streetType;
            IdStreet = idStreet;
            NumHome = numHome;
            NumCase = numCase;
            NumApartment = numApartment;
        }

        public Address(IAddress address)
        {
            IdCountry = address.IdCountry;
            Postcode = address.Postcode;
            IdState = address.IdState;
            District = address.District;
            IdCity = address.IdCity;
            IdLocality = address.IdLocality;
            IdStreet = address.IdStreet;
            NumHome = address.NumHome;
            NumCase = address.NumCase;
            NumApartment = address.NumApartment;
            IdEmployee = address.IdEmployee;
        }

        [Obsolete]
        public Address()
        {
            // required by EF
        }

    }
}
