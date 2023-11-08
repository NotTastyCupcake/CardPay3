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
    /// Логика взаимодействия для MenuView.xaml
    /// </summary>
    public partial class MenuView : IViewFor<MenuViewModel>
    {
        public MenuView(MenuViewModel viewModel = null)
        {
            ViewModel = viewModel ?? Locator.Current.GetService<MenuViewModel>();
            DataContext = ViewModel;

            InitializeComponent();
            this.WhenActivated(disposable =>
            {
                /* Привязка команд к кнопкам */
                this.BindCommand(this.ViewModel,
                    vm => vm.RoutingEmployeeCommand,
                    view => view.EmployeeListButton)
                    .DisposeWith(disposable);
            });

                

        }
    }
}
