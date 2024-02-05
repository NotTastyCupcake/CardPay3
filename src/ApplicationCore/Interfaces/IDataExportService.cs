using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Interfaces
{
    public interface IDataExportService
    {
        /// <summary>
        /// Асинхронный метод для выгрузки данных в файл
        /// </summary>
        /// <param name="format">Формат файла</param>
        /// <param name="path">Путь до файла</param>
        Task ExportDataAsync(string format, string path, int organizationId);
    }
}
