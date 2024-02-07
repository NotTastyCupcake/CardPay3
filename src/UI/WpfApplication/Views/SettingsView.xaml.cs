using Metcom.CardPay3.WpfApplication.ViewModels;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Metcom.CardPay3.WpfApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для SettingsView.xaml
    /// </summary>
    public partial class SettingsView : IViewFor<SettingsViewModel>
    {
        public SettingsView(SettingsViewModel viewModel = null)
        {
            ViewModel = viewModel ?? Locator.Current.GetService<SettingsViewModel>();
            DataContext = ViewModel;

            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                //this.OneWayBind(this.ViewModel,
                //    vm => vm.DBTypes,
                //    view => view.TypesComboBox.ItemsSource)
                //.DisposeWith(disposable);

                this.Bind(this.ViewModel,
                    vm => vm.SelectedDataBaseType,
                    view => view.TypesComboBox.SelectedItem)
                .DisposeWith(disposable);

                this.Bind(this.ViewModel,
                    vm => vm.ConnectionString,
                    view => view.ConnectionString.Text)
                .DisposeWith(disposable);

                this.BindCommand(this.ViewModel,
                    vm => vm.SaveCommand,
                    view => view.SaveButton)
                .DisposeWith(disposable);

            });
        }
    }
}
