﻿using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Metcom.CardPay3.Integration.Interfaces;
using Metcom.CardPay3.Integration.Models;
using Metcom.CardPay3.Integration.Models.OneC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Integration.Services
{
    public class OneCMappingService : IOneCMappingService
    {
        public Employee MapFromOneC(СчетПК item)
        {
            //TODO: Разработать маппинг счета ПК
            throw new NotImplementedException();
        }

        public СчетПК MapToOneC(Organization organization, СчетПК.ItemChoiceType type)
        {

            if(type == СчетПК.ItemChoiceType.ОткрытиеСчетов)
            {
                return new СчетПК()
                {
                    ДатаФормирования = organization.CreateDate,
                    НомерДоговора = organization.ApplicationNumber,
                    ДатаДоговора = organization.ApplicationDate,
                    НаименованиеОрганизации = organization.Name,
                    ИНН = organization.INN,
                    РасчетныйСчетОрганизации = organization.Account,
                    БИК = organization.BankCode,
                    ИдПервичногоДокумента = organization.SourceId,
                    //НомерРеестра = organization.
                    ДатаРеестра = DateTime.Now,
                    Item = ConvertToOpenAccount(organization.Employees.Where(e => e.Requisite.IdStatus == 1))
                };
            }
            else
            {
                return new СчетПК();
            }

        }

        private ОткрытиеСчетов ConvertToOpenAccount(IEnumerable<Employee> employees)
        {
            return new ОткрытиеСчетов() 
            { 
                Сотрудник = employees
                                .Select(e => new ОткрытиеСчетовСотрудник() 
                                {
                                    Фамилия = e.LastName,
                                    Имя = e.FirstName,
                                    Отчество = e.MiddleName,
                                    //TODO: Обязательность заполнения определяется Банком
                                    ОтделениеБанка = e.Requisite.Division.DivisionName,
                                    ФилиалОтделенияБанка = "",
                                    ВидВклада = ConvertCardType(e.Requisite),
                                    УдостоверениеЛичности = ConverDocument(e.Document),
                                    ДатаРождения = e.BirthdayDate,
                                    Пол = e.Gender.GenderName,
                                    //АдресМестаРаботы = ConvertAddress(e.Addresses)
                                    Должность = e.Position,
                                    //МестоРождения = ConvertAddress(e.Addresses)
                                    //АдресПрописки = ConvertAddress(e.Addresses)
                                    РабочийТелефон = new string[] { e.JobPhoneNumber },
                                    //ДомашнийТелефон = new string[] { e.PhoneNumber },
                                    ЭмбоссированныйТекст = new ОткрытиеСчетовСотрудникЭмбоссированныйТекст() 
                                    { 
                                        Поле1 = e.Requisite.LatinFirstName, 
                                        Поле2 = e.Requisite.LatinLastName 
                                    },
                                    //Сумма = 
                                    //Код валют =
                                    Резидент = e.Resident,
                                    Гражданство = e.Nationality,
                                    КатегорияНаселения = e.Type?.Code.ToString() ?? "",
                                    //БонусУчастника =
                                    //ПризнакРассылки =
                                    ИнтернетАдрес = e.EMail,
                                    //СчетДебета = 
                                    МобильныйТелефон = e.PhoneNumber,
                                    //ПередачаБКИ = e.
                                    //КонтрольнаяИнформация = e.
                                }).ToArray() 
            };
        }

        private УдостоверениеЛичности ConverDocument(DocumentItem document)
        {
            return new УдостоверениеЛичности()
            {
                ВидДокумента = document.Type.Name,
                Серия = document.Series,
                Номер = document.Number,
                ДатаВыдачи = document.DataIssued,
                КемВыдан = document.IssuedBy,
                КодВидаДокумента = document.Type.Code.ToString(),
                КодПодразделения = document.SubdivisionCode,
            };
        }

        private ВидВклада ConvertCardType(RequisitesItem req)
        {
            //TODO: Заполнение полей вида вклада
            return new ВидВклада() { Value = req.CardType.NameType ?? "" };
        }

        
        private Адрес ConvertAddress(ICollection<Address> addresses)
        {
            //TODO: Маппинг адреса
            throw new NotImplementedException();
        }
    }
}