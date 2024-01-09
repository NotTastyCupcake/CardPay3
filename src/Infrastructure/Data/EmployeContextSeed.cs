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

                if (!employerContext.TypeEmployers.Any())
                {
                    employerContext.TypeEmployers.AddRange(
                        GetPreconfiguredTypeEmployers());

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

            }
            catch (Exception ex)
            {
                var log = loggerFactory.CreateLogger<EmployeContextSeed>();
                log.LogError(ex.Message);
                await SeedAsync(employerContext, loggerFactory);
            }

        }


        private static IEnumerable<DocumentType> GetPreconfiguredDocumentTypes()
        {
            return new List<DocumentType>()
            {
                new DocumentType("Паспорт гражданина СССР", 1),
                new DocumentType("Загранпаспорт гражданина СССР", 2),
                new DocumentType("Свидетельство о рождении", 3),
                new DocumentType("Удостоверение личности офицера", 4),
                new DocumentType("Справка об освобождении из места лишения свободы", 5),
                new DocumentType("Военный билет солдата (матроса, сержанта, старшины)", 7),
                new DocumentType("Дипломатический паспорт гражданина РФ", 9),
                new DocumentType("Иностранный паспорт", 10),
                new DocumentType("Свидетельство о регистрации ходатайства иммигранта о признании его беженцем", 11),
                new DocumentType("Вид на жительство", 12),
                new DocumentType("Удостоверение беженца в РФ", 13),
                new DocumentType("Временное удостоверение личности гражданина РФ", 14),
                new DocumentType("Паспорт гражданина РФ", 21),
                new DocumentType("Загранпаспорт гражданина РФ ", 22),
                new DocumentType("Свидетельство о рождении, выданное уполномоченным органом иностранного государства", 23),
                new DocumentType("Паспорт моряка", 26),
                new DocumentType("Военный билет офицера запаса", 27),
                new DocumentType("Иные документы, выдаваемые органами МВД ", 91),
                new DocumentType("Временное удостоверение, выданное взамен военного билета ", 8),
                new DocumentType("Разрешение на временное проживание", 15),
                new DocumentType("Свидетельство о предоставлении временного убежища на территории Российской Федерации", 18),
                new DocumentType("Удостоверение личности военнослужащего Российской Федерации", 24)

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
                new Geographic("Российская фидерация", "RUS", 643),
                new Geographic("Беларуссия", "BLR", 112)
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

        private static IEnumerable<EmployeeType> GetPreconfiguredTypeEmployers()
        {
            return new List<EmployeeType>()
            {
                new EmployeeType(207, "Лица, перечисляющие зарплату на счета"),
                new EmployeeType(0, "Пенсионеры"),
                new EmployeeType(212, "Зарплата с разрешенным овердрафтом для сотрудников банка"),
                new EmployeeType(217, "Зарплата с разрешенным овердрафтом для сотрудников организации"),
                new EmployeeType(218, "Студенческая (договор с учебным заведением)")
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

    }
}