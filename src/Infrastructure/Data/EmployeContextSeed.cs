using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.GroupAggregate;
using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Data
{
    public class EmployeContextSeed
    {
        public async static Task SeedAsync(EmployeContext employerContext,
            ILoggerFactory loggerFactory)
        {
            try
            {

                if (!employerContext.Organizations.Any())
                {
                    employerContext.Organizations.AddRange(
                        GetPreconfiguredOrganizations());

                    await employerContext.SaveChangesAsync();
                }

                //if (!employerContext.Groups.Any())
                //{
                //    employerContext.Groups.AddRange(
                //        GetPreconfiguredGroups());

                //    await employerContext.SaveChangesAsync();
                //}

                if (!employerContext.Genders.Any())
                {
                    employerContext.Genders.AddRange(
                        GetPreconfiguredGenders());

                    await employerContext.SaveChangesAsync();
                }

                if (!employerContext.Banks.Any())
                {
                    employerContext.Banks.AddRange(
                        GetPreconfiguredBankDivision());

                    await employerContext.SaveChangesAsync();
                }
                if (!employerContext.Currencies.Any())
                {
                    employerContext.Currencies.AddRange(
                        GetPreconfiguredBankCurrencies());

                    await employerContext.SaveChangesAsync();
                }

                if (!employerContext.CardTypes.Any())
                {
                    employerContext.CardTypes.AddRange(
                        GetPreconfiguredBankCardTypes());

                    await employerContext.SaveChangesAsync();
                }

                if (!employerContext.Operations.Any())
                {
                    employerContext.Operations.AddRange(
                        GetPreconfiguredOperations());

                    await employerContext.SaveChangesAsync();
                }

                if (!employerContext.DocumentTypes.Any())
                {
                    employerContext.DocumentTypes.AddRange(
                        GetPreconfiguredDocumentTypes());

                    await employerContext.SaveChangesAsync();
                }


                if (!employerContext.Documents.Any())
                {
                    employerContext.Documents.AddRange(
                        GetPreconfiguredDocuments());

                    await employerContext.SaveChangesAsync();
                }

                if (!employerContext.Employers.Any())
                {
                    employerContext.Employers.AddRange(
                        GetPreconfiguredEmployers());

                    await employerContext.SaveChangesAsync();
                }

                if (!employerContext.Requisites.Any())
                {
                    employerContext.Requisites.AddRange(
                        GetPreconfiguredRequisites());

                    await employerContext.SaveChangesAsync();
                }

                if (!employerContext.Addresses.Any())
                {
                    employerContext.Addresses.AddRange(
                        GetPreconfiguredAddresses());

                    await employerContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var log = loggerFactory.CreateLogger<EmployeContextSeed>();
                log.LogError(ex.Message);
                //await SeedAsync(employerContext, loggerFactory);
            }

        }

        private static IEnumerable<DocumentType> GetPreconfiguredDocumentTypes()
        {
            return new List<DocumentType>()
            {
                new DocumentType("Военный билет"),
                new DocumentType("Паспорт")
            };
        }

        private static IEnumerable<DocumentItem> GetPreconfiguredDocuments()
        {
            return new List<DocumentItem>()
            {
                new DocumentItem(1,DateTime.Now,"TEST_ISSUED_BY","TEST_SUBDIVISION"),
                new DocumentItem(1,DateTime.Now,"TEST_ISSUED_BY2","TEST_SUBDIVISION2")
            };
        }

        private static IEnumerable<Organization> GetPreconfiguredOrganizations()
        {
            return new List<Organization>()
            {
                new Organization("ПАО \"МЕТКОМБАНК\""),
                new Organization("ОАО \"ТЕСТ\"")
            };
        }

        private static IEnumerable<OperationType> GetPreconfiguredOperations()
        {
            return new List<OperationType>()
            {
                new OperationType("Зачисление"),
                new OperationType("Списание"),
                new OperationType("Заморозка")
            };
        }

        private static IEnumerable<Geographic> GetPreconfiguredGeographics()
        {
            return new List<Geographic>()
            {
                new Geographic("Российская фидерация", "RUS", "643"),
                new Geographic("TEST_STATE", "TEST_SHORT_STATE"),
                new Geographic("TEST_CITY", "TEST_SHORT_CITY"),
                new Geographic("TEST_LOCALITY", "TEST_SHORT_LOCALITY"),
                new Geographic("TEST_STREET", "TEST_SHORT_STREET")
            };

        }

        private static IEnumerable<Address> GetPreconfiguredAddresses()
        {
            return new List<Address>()
            {
                new Address( 1, 1, 2, "TEST_DISTRICT", 3, 4, "TEST_STREET_TYPE", 5, 1, 1, 1, 1)
            };

        }

        private static IEnumerable<RequisitesItem> GetPreconfiguredRequisites()
        {
            return new List<RequisitesItem>()
            {
                new RequisitesItem("IVAN","IVANOV","0000 0000 0000 0000", "00000", 1,11111,"INSURANCE_NUM", 1, 1, 1)
            };
        }

        private static IEnumerable<Gender> GetPreconfiguredGenders()
        {
            return new List<Gender>()
            {
                new Gender("Мужчика","М"),
                new Gender("Женшина","Ж")
            };
        }

        private static IEnumerable<Group> GetPreconfiguredGroups()
        {
            return new List<Group>()
            {
                new Group(1, "GROUP_1")
            };
        }
        private static IEnumerable<BankCurrency> GetPreconfiguredBankCurrencies()
        {
            return new List<BankCurrency>()
            {
               new BankCurrency("Рубли"),
               new BankCurrency("Тэнге")
            };
        }

        private static IEnumerable<BankCardType> GetPreconfiguredBankCardTypes()
        {
            return new List<BankCardType>()
            {
               new BankCardType("МИР")
            };
        }


        private static IEnumerable<BankDivision> GetPreconfiguredBankDivision()
        {
            return new List<BankDivision>()
            {
                new BankDivision("ПАО \"МЕТКОМБАНК\" г.Екатеринбург ул. Малышева"),
                new BankDivision("ЦО ДО \"МЕТКОМБАНК\" г.Екатеринбург ул. Малышева")
            };
        }

        private static IEnumerable<Employe> GetPreconfiguredEmployers()
        {
            return new List<Employe>()
            {
                new Employe("Иванов", "Иван", "Иванович", "TEST_PHONE", "TEST_JOB", "TEST_POSITION", "TEST_DEPATMENT_NUM", 2, 1, 1),
                new Employe("Иванова", "Аня", "Ивановна", "TEST_PHONE", "TEST_JOB", "TEST_POSITION", "TEST_DEPATMENT_NUM", 1, 2, 1)
            };
        }
    }
}