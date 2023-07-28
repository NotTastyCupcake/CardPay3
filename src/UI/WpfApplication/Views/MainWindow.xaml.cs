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

namespace Metcom.CardPay3.WpfApplication;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, IViewFor<HomeViewModel>
{
    public static readonly DependencyProperty ViewModelProperty = DependencyProperty
        .Register(nameof(ViewModel), typeof(HomeViewModel), typeof(MainWindow));

    public MainWindow()
    {
        InitializeComponent();
        ViewModel = new HomeViewModel();
        //TODO: Добавить значение "Создать организацию"
        this.WhenActivated(disposable => {
            this.OneWayBind(this.ViewModel,
                            vm => vm.Organizations,
                            view => view.Organizations.ItemsSource)
            .DisposeWith(disposable);
        });
    }

    public HomeViewModel ViewModel { get => (HomeViewModel)GetValue(ViewModelProperty); set => SetValue(ViewModelProperty, value); }
    object IViewFor.ViewModel { get => ViewModel; set => ViewModel = (HomeViewModel)value; }
}
