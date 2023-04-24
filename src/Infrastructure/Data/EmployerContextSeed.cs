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
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Data
{
    public class EmployerContextSeed
    {
        public async static Task SeedAsync(EmployerContext employerContext, 
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

                if (!employerContext.Groups.Any())
                {
                    employerContext.Groups.AddRange(
                        GetPreconfiguredGroups());

                    await employerContext.SaveChangesAsync();
                }

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
            }
            catch (Exception ex)
            {
                var log = loggerFactory.CreateLogger<EmployerContextSeed>();
                log.LogError(ex.Message);
                await SeedAsync(employerContext, loggerFactory);
            }

        }

        private static IEnumerable<DocumentType> GetPreconfiguredDocumentTypes()
        {
            return new List<DocumentType>()
            {
                new DocumentType("ПАО \"МЕТКОМБАНК\""),
                new DocumentType("ОАО \"ТЕСТ\"")
            };
        }

        private static IEnumerable<DocumentItem> GetPreconfiguredDocuments()
        {
            return new List<DocumentItem>()
            {
                new DocumentItem(1,DateTime.Now,"TEST_ISSUED_BY","TEST_SUBDIVISION")
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

        private static IEnumerable<Address> GetPreconfiguredAddresses()
        {
            return new List<Address>()
            {
                new Address("TEST_COUNTRY", 1, "TEST_STATE", "TEST_DISTRICT", "TEST_CITY", "TEST_LOCATION", "TEST_STREET_TYPE", "TEST_STREET", 1, 1, 1, 1)
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
               new BankCurrency("Рубли")
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
                new BankDivision("ПАО \"МЕТКОМБАНК\" г.Екатеринбург ул. Малышева")
            };
        }

        private static IEnumerable<Employer> GetPreconfiguredEmployers()
        {
            return new List<Employer>()
            {
                new Employer("Иванов", "Иван", "Иванович", "TEST_PHONE", "TEST_JOB", "TEST_POSITION", "TEST_DEPATMENT_NUM", 1, 1, 1)
            };
        }
    }
}