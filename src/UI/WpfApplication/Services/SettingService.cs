using Metcom.CardPay3.WpfApplication.Interfaces;
using Metcom.CardPay3.WpfApplication.Models;
using Metcom.CardPay3.WpfApplication.Properties;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication.Services
{
    public class SettingService : ISettingService
    {
        private readonly IConfiguration _configuration;
        private readonly string _settingsFile;
        public SettingService(IConfiguration configuration)
        {
            _configuration = configuration;
            _settingsFile = "appsettings.json";
        }

        public SettingModel GetSetting()
        {
            return new SettingModel()
            {
                ConnectionString = _configuration.GetConnectionString("MainConnection"),
                DataBaseType = _configuration["DataBaseType"]
            };
        }

        public void SaveChange(SettingModel newSetting)
        {
            var settings = _configuration.AsEnumerable();
            var settingsCollection = new Dictionary<string, string>();

            foreach (var item in settings)
            {
                if(item.Key == "ConnectionString:MainConnection")
                {
                    settingsCollection.Add(item.Key, newSetting.ConnectionString);
                }
                else if(item.Key == "DataBaseType")
                {
                    settingsCollection.Add(item.Key, newSetting.DataBaseType);
                }
                else
                {
                    settingsCollection.Add(item.Key, item.Value);
                }
            }

            File.WriteAllText(_settingsFile, JsonConvert.SerializeObject(settingsCollection, Formatting.Indented));
        }
    }
}
