namespace Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate
{
    public class Address : BaseEntity, IAddress
    {
#nullable enable
        public int? IdEmployer { get; private set; }
        public virtual Employe? Employer { get; private set; }
#nullable disable

        #region Поля

        public string FullName => $"{Postcode}, {Country.Name}, {State.Name}, {City.Name},{StreetType} {Street.Name},д. {NumHome}";
        /// <summary>
        /// Индекс
        /// </summary>
        public int Postcode { get; private set; }

        public int IdCountry { get; private set; }
        public virtual Geographic Country { get; private set; }

        public int IdState { get; private set; }
        /// <summary>
        /// Регион
        /// </summary>
        public virtual Geographic State { get; private set; }

        /// <summary>
        /// Район
        /// </summary>
        public string District { get; private set; }

        public int IdCity { get; private set; }
        public virtual Geographic City { get; private set; }


        public int IdLocality { get; private set; }
        /// <summary>
        /// Населенный пункт
        /// </summary>
        public virtual Geographic Locality { get; private set; }

        /// <summary>
        /// Тип улицы
        /// </summary>
        public string StreetType { get; private set; }

        public int IdStreet { get; private set; }
        public virtual Geographic Street { get; private set; }

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

        public Address(int idCountry, int postcode, int idState, string district, int idCity, int idLocality, string streetType, int idStreet, int numHome, int numCase, int numApartment, int idEmployer)
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
            IdEmployer = idEmployer;
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
            IdEmployer = address.IdEmployer;
        }

        public Address()
        {
            // required by EF
        }

    }
}
