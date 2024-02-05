using Metcom.CardPay3.WpfApplication.ViewModels.Employes;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Formatters;
using Splat;
using System;
using System.Linq;
using System.Reactive.Disposables;

namespace Metcom.CardPay3.WpfApplication.Views.Employes
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeWindow.xaml
    /// </summary>
    public partial class EditEmployeeView
    {

        public EditEmployeeView(EditEmployeeViewModel viewModel = null)
        {
            ViewModel = viewModel ?? Locator.Current.GetService<EditEmployeeViewModel>();
            DataContext = ViewModel;

            InitializeComponent();


            this.WhenActivated(disposable =>
            {
                #region Выгрузка коллекций для создания сотрудника
                this.OneWayBind(this.ViewModel,
                    vm => vm.Genders,
                    view => view.GendersComboBox.ItemsSource)
                    .DisposeWith(disposable);

                this.OneWayBind(this.ViewModel,
                    vm => vm.EmployeeTypes,
                    view => view.TypesComboBox.ItemsSource)
                    .DisposeWith(disposable); 
                #endregion


                this.Bind(this.ViewModel,
                    vm => vm.Gender,
                    view => view.GendersComboBox.SelectedItem)
                    .DisposeWith(disposable);

                this.Bind(this.ViewModel,
                    vm => vm.FirstName,
                    view => view.FirstNameBlock.Text)
                    .DisposeWith(disposable);


                this.Bind(this.ViewModel,
                    vm => vm.LastName,
                    view => view.LastNameBlock.Text)
                    .DisposeWith(disposable);

                this.Bind(this.ViewModel,
                    vm => vm.MiddleName,
                    view => view.MiddleNameBlock.Text)
                    .DisposeWith(disposable);


                this.Bind(this.ViewModel,
                    vm => vm.BirthdayDateSelector,
                    view => view.BirthdayDatePicker.SelectedDate)
                    .DisposeWith(disposable);


                this.Bind(this.ViewModel,
                    vm => vm.PhoneNumber,
                    view => view.PhoneNumber.Text)
                    .DisposeWith(disposable);


                this.Bind(this.ViewModel,
                    vm => vm.JobPhoneNumber,
                    view => view.JobPhoneNumber.Text)
                    .DisposeWith(disposable);


                this.Bind(this.ViewModel,
                    vm => vm.Position,
                    view => view.Position.Text)
                    .DisposeWith(disposable);


                this.Bind(this.ViewModel,
                    vm => vm.DepartmentNum,
                    view => view.DepartmentNum.Text)
                    .DisposeWith(disposable);


                //this.Bind(this.ViewModel,
                //    vm => vm.Employee.Addresses.FirstOrDefault().FullName,
                //    view => view.AddressTextBlock.Text)
                //    .DisposeWith(disposable);

                this.Bind(this.ViewModel,
                    vm => vm.Document.FullName,
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


                this.BindValidation(this.ViewModel,
                    vm => vm.FirstName,
                    view => view.FirstNameError.Content)
                    .DisposeWith(disposable);

                this.BindValidation(this.ViewModel,
                    vm => vm.LastName,
                    view => view.LastNameError.Content)
                    .DisposeWith(disposable);

                this.BindValidation(this.ViewModel,
                    vm => vm.Gender,
                    view => view.GendersError.Content)
                    .DisposeWith(disposable);

                this.BindValidation(this.ViewModel,
                    vm => vm.BirthdayDate,
                    view => view.BirthdayError.Content)
                    .DisposeWith(disposable);

                this.BindValidation(this.ViewModel,
                    vm => vm.Document,
                    view => view.DocumentError.Content)
                    .DisposeWith(disposable);

                /* Привязка команд к кнопкам */

                this.BindCommand(this.ViewModel,
                    vm => vm.EditEmployeeCommand,
                    view => view.Create)
                .DisposeWith(disposable);

                this.BindCommand(this.ViewModel,
                    vm => vm.EditDocumentCommand,
                    view => view.CreateDocument)
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
