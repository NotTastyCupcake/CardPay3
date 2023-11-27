using Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Services
{
    public class RequisitesService : IRequisitesService
    {
        public Task AddRequisite(int inn, 
                                string insuranceNum, 
                                int idDivision, 
                                int idCurrency, 
                                int idCardType, 
                                int idEmployer, 
                                
                                string latinFirstName = null, 
                                string latinLastName = null)
        {
            //TODO: Создание заявки на открытия ЗП счета в банке
            throw new NotImplementedException();
        }

        public Task UpdateCard(string lastName, 
                               string firstName, 
                               string middleName, 
                               
                               string cardNumber, 
                               string accountNumber, 
                               int typeCardCode)
        {
            //TODO: Получение реквезитов карты из банка
            throw new NotImplementedException();
        }
    }
}
