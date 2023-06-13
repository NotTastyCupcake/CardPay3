using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WebApplication.ViewModels.Employes
{
    public class EmployeAddressViewModel
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public int Postcode { get; set; }
        /// <summary>
        /// Регион
        /// </summary>
        public string State { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        /// <summary>
        /// Населенный пункт
        /// </summary>
        public string Locality { get; set; }
        /// <summary>
        /// Тип улицы
        /// </summary>
        public string StreetType { get; set; }
        public string Street { get; set; }
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

        public string FullName => 
            $"{StreetType} {Street}, " +
            $"дом {NumHome}, " +
            $"{(NumCase != 0 ? "корпус " + NumCase + ", " : "")}" +
            $"{(NumCase != 0 ? "кв. " + NumApartment + ", " : "")}" +
            $"город {City}" +
            $"страна {Country}";
    }
}
