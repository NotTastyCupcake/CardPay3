using Castle.Core.Configuration;
using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.WpfApplication.Interfaces;
using Metcom.CardPay3.WpfApplication.Models;
using Metcom.CardPay3.WpfApplication.Properties;
using Microsoft.VisualBasic;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metcom.CardPay3.WpfApplication.ViewModels
{
    public class SettingsViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "Setting"; } }
        public IScreen HostScreen { get; protected set; }

        private readonly ISettingService _service;

        public SettingsViewModel(ISettingService service ,IScreen screen = null)
        {
            _service = service;

            HostScreen = screen;

            var settings = service.GetSetting();

            SelectedDataBaseType = settings.DataBaseType;
            ConnectionString = settings.ConnectionString;

            SaveCommand = ReactiveCommand.CreateFromTask(async delegate ()
            {
                service.SaveChange(new SettingModel() 
                { 
                    ConnectionString = ConnectionString,
                    DataBaseType = SelectedDataBaseType
                });
                MessageBox.Show("Чтобы применить настройки, перезапустите приложение.");
                await HostScreen.Router.NavigateBack.Execute();
            });

            DBTypes = new ObservableCollection<string>()
            {
                "PostgresSQL",
                "MSSQL"
            };

        }

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }

        [Reactive]
        public ObservableCollection<string> DBTypes { get; set; }
        [Reactive]
        public string SelectedDataBaseType { get; set; }
        [Reactive]
        public string ConnectionString { get; set; }

    }
}
