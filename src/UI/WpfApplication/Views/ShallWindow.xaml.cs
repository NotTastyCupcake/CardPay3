using Metcom.CardPay3.WpfApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
using ReactiveUI;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Splat;

namespace Metcom.CardPay3.WpfApplication;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class ShellWindow : IViewFor<HomeViewModel>
{

    public ShellWindow(HomeViewModel viewModel = null)
    {
        ViewModel = viewModel ?? Locator.Current.GetService<HomeViewModel>();
        DataContext = ViewModel;

        InitializeComponent();

        this.WhenActivated(disposable => 
        {

            // Двунаправленная привязка значения позиции клапана. Конверторы значений свойства в модели и в представлении: FloatToStringConverter, StringToFloatConverter
            this.OneWayBind(this.ViewModel,
                vm => vm.Organizations,
                view => view.Organizations.ItemsSource)
            .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.SelectedOrganization,
                view => view.Organizations.SelectedItem)
            .DisposeWith(disposable);


            /* Привязка команд к кнопкам */
            this.BindCommand(this.ViewModel,
                vm => vm.RoutingGoBackCommand,
                view => view.GoBackButton)
            .DisposeWith(disposable);

            // routing
            this.OneWayBind(ViewModel,
                    x => x.Router,
                    x => x.RoutedViewHost.Router)
                .DisposeWith(disposable);

        });
    }

}
