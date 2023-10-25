using Metcom.CardPay3.WpfApplication.ViewModels;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Metcom.CardPay3.WpfApplication.Views.Employes
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeWindow.xaml
    /// </summary>
    public partial class EmployeWindow
    {

        public EmployeWindow(EmployeViewModel viewModel = null)
        {
            ViewModel = viewModel ?? Locator.Current.GetService<EmployeViewModel>();
            DataContext = ViewModel;

            InitializeComponent();


            this.WhenActivated(disposable =>
            {
                this.OneWayBind(this.ViewModel,
                    vm => vm.Genders,
                    view => view.GendersComboBox.ItemsSource)
                    .DisposeWith(disposable);


                this.Bind(this.ViewModel,
                    vm => vm.SelectedGender,
                    view => view.GendersComboBox.SelectedItem)
                    .DisposeWith(disposable);

                this.Bind(this.ViewModel,
                    vm => vm.Employe.FirstName,
                    view => view.FirstNameBlock.Text)
                    .DisposeWith(disposable);

                this.Bind(this.ViewModel,
                    vm => vm.Employe.LastName,
                    view => view.LastNameBlock.Text)
                    .DisposeWith(disposable);

                this.Bind(this.ViewModel,
                    vm => vm.Employe.MiddleName,
                    view => view.MiddleNameBlock.Text)
                    .DisposeWith(disposable);


                this.Bind(this.ViewModel,
                    vm => vm.Employe.PhoneNumber,
                    view => view.PhoneNumber.Text)
                    .DisposeWith(disposable);


                this.Bind(this.ViewModel,
                    vm => vm.Employe.JobPhoneNumber,
                    view => view.JobPhoneNumber.Text)
                    .DisposeWith(disposable);


                this.Bind(this.ViewModel,
                    vm => vm.Employe.Position,
                    view => view.Position.Text)
                    .DisposeWith(disposable);


                this.Bind(this.ViewModel,
                    vm => vm.Employe.DepartmentNum,
                    view => view.DepartmentNum.Text)
                    .DisposeWith(disposable);


                this.Bind(this.ViewModel,
                    vm => vm.AddressFullName,
                    view => view.AddressTextBlock.Text)
                    .DisposeWith(disposable);

                this.Bind(this.ViewModel,
                    vm => vm.DocumentFullName,
                    view => view.DocumentTextBlock.Text)
                    .DisposeWith(disposable);

                //this.Bind(this.ViewModel,
                //    vm => vm.Employe.Gender,
                //    view => view.IdGender.Text)
                //    .DisposeWith(disposable);


                //this.Bind(this.ViewModel,
                //    vm => vm.Employe.Document,
                //    view => view.IdDocument.Text)
                //    .DisposeWith(disposable);


                /* Привязка команд к кнопкам */

                this.BindCommand(this.ViewModel,
                    vm => vm.ActionCommand,
                    view => view.Create)
                .DisposeWith(disposable);

                this.BindCommand(this.ViewModel,
                    vm => vm.CreateAddress,
                    view => view.CreateAddress,
                    vm => vm.Address)
                .DisposeWith(disposable);

                this.BindCommand(this.ViewModel,
                    vm => vm.CreateDocument,
                    view => view.CreateDocument,
                    vm => vm.Document)
                .DisposeWith(disposable);


            });




            ////enable buttons
            //this.OneWayBind(this.ViewModel,
            //    vm => vm.IsRealOrganization,
            //    view => view.EmployeeListButton.IsEnabled)
            //.DisposeWith(disposable);

            //this.OneWayBind(this.ViewModel,
            //    vm => vm.IsRealOrganization,
            //    view => view.AccryalListButton.IsEnabled)
            //.DisposeWith(disposable);

            ///* Привязка команд к кнопкам */
            //this.BindCommand(this.ViewModel,
            //    vm => vm.RoutingEmployeeCommand,
            //    view => view.EmployeeListButton)
            //.DisposeWith(disposable);

            //this.BindCommand(this.ViewModel,
            //    vm => vm.RoutingAccrualCommand,
            //    view => view.AccryalListButton)
            //.DisposeWith(disposable);

            //// routing
            //this.OneWayBind(ViewModel,
            //        x => x.Router,
            //x => x.RoutedViewHost.Router)
            //    .DisposeWith(disposable);
        }
    }
}
