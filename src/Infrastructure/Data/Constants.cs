using Metcom.CardPay3.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Data
{
    public static class Constants
    {

    }

    public static class StatusList
    {
        public static Status Draft = new Status("Черновик", "");
        public static Status Processing = new Status("Обрабатывается банком", "Отправлена заявка на открытие счета.");
        public static Status Added = new Status("Добавлен", "Получен результат открытия счета в банке.");
        public static Status Fired = new Status("Уволен", "");
    }
}
