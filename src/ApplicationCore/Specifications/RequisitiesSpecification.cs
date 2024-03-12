using Ardalis.Specification;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metcom.CardPay3.ApplicationCore.Specifications
{
    public sealed class RequisitiesSpecification : Specification<RequisitesItem> , ISingleResultSpecification<RequisitesItem>
    {
        /// <summary>
        /// Поиск схожих заявок на открытие счета
        /// </summary>
        public RequisitiesSpecification(int inn, string insuranceNum,int idDivision, int idCurrency, int idCardType)
        {
            Query
                .Where(a => 
                       a.INN == inn 
                       && a.InsuranceNumber == insuranceNum 
                       && a.IdDivision == idDivision 
                       && a.IdCurrency == idCurrency
                       && a.IdCardType == idCardType);
        }
    }
}
