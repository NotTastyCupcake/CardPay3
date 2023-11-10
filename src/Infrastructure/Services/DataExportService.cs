using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Metcom.CardPay3.Infrastructure.Services
{
    public class DataExportService : IDataExportService
    {
        // Контекст базы данных
        private readonly EmployeContext _context;

        // Конструктор, который принимает контекст базы данных
        public DataExportService(EmployeContext context)
        {
            _context = context;
        }

        // Метод для выгрузки данных в файл
        public async Task ExportDataAsync(string format, string path)
        {
            // Получаем данные из базы данных
            var data = await _context.Employers.ToListAsync();

            // Создаем поток для записи в файл
            using (var stream = File.Create(path))
            {
                // Проверяем формат файла
                if (format == "json")
                {
                    // Сериализуем данные в JSON
                    var json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                    // Записываем JSON в файл
                    using (var writer = new StreamWriter(stream))
                    {
                        await writer.WriteAsync(json);
                    }
                }
                else if (format == "xml")
                {
                    //TODO: Исправить ошибку сервиализации типа List<Employe> без атребутов
                    // Сериализуем данные в XML
                    //var xml = new XmlSerializer(data.GetType());

                    // Записываем XML в файл
                    //xml.Serialize(stream, data);
                }
                else
                {
                    // Бросаем исключение, если формат не поддерживается
                    throw new ArgumentException("Unsupported format");
                }
            }
        }
    }

}
