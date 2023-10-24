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
    /// Логика взаимодействия для EmployeListView.xaml
    /// </summary>
    public partial class EmployeListView
    {
        public EmployeListView(EmployeeListViewModel viewModel = null)
        {
            ViewModel = viewModel ?? Locator.Current.GetService<EmployeeListViewModel>();
            DataContext = ViewModel;

            InitializeComponent();


            this.WhenActivated(disposable =>
            {
                this.OneWayBind(this.ViewModel,
                    vm => vm.Employes,
                    view => view.Employes.ItemsSource)
                .DisposeWith(disposable);


                this.Bind(this.ViewModel,
                    vm => vm.SelectedEmploye,
                    view => view.Employes.SelectedItem)
                .DisposeWith(disposable);

                this.BindCommand(this.ViewModel,
                    vm => vm.RoutingAddEmployeeCommand,
                    view => view.CreateEmployeButton)
                .DisposeWith(disposable);

                this.BindCommand(this.ViewModel,
                    vm => vm.RoutingEditEmployeeCommand,
                    view => view.EditCommand)
                    .DisposeWith(disposable);

                this.BindCommand(this.ViewModel,
                    vm => vm.RoutingDeleteEmployeeCommand,
                    view => view.DeleteCommand)
                    .DisposeWith(disposable);

            });
        }
    }
}
