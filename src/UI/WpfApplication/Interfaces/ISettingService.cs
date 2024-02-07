using Metcom.CardPay3.WpfApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Interfaces
{
    public interface ISettingService
    {
        SettingModel GetSetting();
        void SaveChange(SettingModel setting);
    }
}
