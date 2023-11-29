using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Interfaces.ServicesInterfaces
{
    public interface IRequisitesService
    {
        /// <summary>
        /// Заявка на создание счета в банке
        /// </summary>
        /// <param name="inn">ИНН</param>
        /// <param name="insuranceNum">Страховой номер</param>
        /// <param name="idDivision">Отделение банка</param>
        /// <param name="idCurrency">Валюта</param>
        /// <param name="idCardType">Тип карты</param>
        /// <param name="idEmployer">Сотрудник на которого открывают карту</param>
        /// <param name="latinFirstName">Имя латиницей</param>
        /// <param name="latinLastName">Фамилия латиницей</param>
        /// <returns></returns>
        Task AddRequisite(int inn,
                          string insuranceNum,
                          int idDivision,
                          int idCurrency,
                          int idCardType,
                          int idEmployer,

                          string latinFirstName = null,
                          string latinLastName = null);

        /// <summary>
        /// Запись данных по карте в базу из банка
        /// </summary>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <param name="middleName">Отчество</param>
        /// <param name="cardNumber">Номер карты</param>
        /// <param name="accountNumber">Счет карты</param>
        /// <param name="typeCardCode">Код типа карты</param>
        /// <returns></returns>
        Task UpdateCard(string lastName, 
                        string firstName, 
                        string middleName, 

                        string cardNumber, 
                        string accountNumber, 
                        int typeCardCode);

    }
}
