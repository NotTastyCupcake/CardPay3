using Metcom.CardPay3.WpfApplication.ViewModels.Employes;
using Microsoft.EntityFrameworkCore.Design.Internal;
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

                BindModel(disposable);

                BindValidationModel(disposable);

                /* Привязка команд к кнопкам */

                this.BindCommand(this.ViewModel,
                    vm => vm.EditEmployeeCommand,
                    view => view.EditEmployeeButton)
                .DisposeWith(disposable);

                this.BindCommand(this.ViewModel,
                    vm => vm.CreateDocumentCommand,
                    view => view.EditDocumentButton)
                .DisposeWith(disposable);

                this.BindCommand(this.ViewModel,
                    vm => vm.CreateRequisitCommand,
                    view => view.EditRequisitButton)
                .DisposeWith(disposable);


            });
        }

        private void BindModel(CompositeDisposable disposable)
        {
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
                vm => vm.BirthdayDateSelected,
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

            this.Bind(this.ViewModel,
                vm => vm.ResidentSelected,
                view => view.Resident.IsChecked)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.Document.FullName,
                view => view.DocumentTextBlock.Text)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.RequisitFullName,
                view => view.RequisitTextBlock.Text)
                .DisposeWith(disposable);
        }

        private void BindValidationModel(CompositeDisposable disposable)
        {
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
                vm => vm.BirthdayDateSelected,
                view => view.BirthdayError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.Document,
                view => view.DocumentError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.ResidentSelected,
                view => view.ResidentError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.Requisite,
                view => view.RequisitError.Content)
                .DisposeWith(disposable);
        }
    }
}
