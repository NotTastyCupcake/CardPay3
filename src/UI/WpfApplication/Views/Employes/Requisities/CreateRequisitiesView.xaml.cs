using Metcom.CardPay3.WpfApplication.ViewModels.Employes.DocumentCRUD;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes.RequisitiesCRUD;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;
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

namespace Metcom.CardPay3.WpfApplication.Views.Employes.Requisities
{
    /// <summary>
    /// Логика взаимодействия для CreateRequisitiesView.xaml
    /// </summary>
    public partial class CreateRequisitiesView
    {
        public CreateRequisitiesView(CreateRequisitiesViewModel viewModel = null)
        {
            ViewModel = viewModel ?? Locator.Current.GetService<CreateRequisitiesViewModel>();
            DataContext = ViewModel;
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.OneWayBind(this.ViewModel,
                    vm => vm.CardTypes,
                    view => view.CardTypeComboBox.ItemsSource)
                    .DisposeWith(disposable);

                this.OneWayBind(this.ViewModel,
                    vm => vm.Currencys,
                    view => view.CurrencyComboBox.ItemsSource)
                    .DisposeWith(disposable);

                this.OneWayBind(this.ViewModel,
                    vm => vm.Divisions,
                    view => view.DivisionComboBox.ItemsSource)
                    .DisposeWith(disposable);

                this.OneWayBind(this.ViewModel,
                    vm => vm.Statuses,
                    view => view.StatusComboBox.ItemsSource)
                    .DisposeWith(disposable);

                BindModel(disposable);

                Validation(disposable);

                this.BindCommand(this.ViewModel,
                    vm => vm.CreateRequisiteCommand,
                    view => view.Create)
                    .DisposeWith(disposable);

            });
        }

        private void BindModel(CompositeDisposable disposable)
        {
            this.Bind(this.ViewModel,
                vm => vm.SelectedCardType,
                view => view.CardTypeComboBox.SelectedItem)
                .DisposeWith(disposable);


            this.Bind(this.ViewModel,
                vm => vm.SelectedBankCurrency,
                view => view.CurrencyComboBox.SelectedItem)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.SelectedDivisions,
                view => view.DivisionComboBox.SelectedItem)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.SelectedStatus,
                view => view.StatusComboBox.SelectedItem)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.SelectedINN,
                view => view.INNBlock.Text)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.InsuranceNumber,
                view => view.InsuranceNumberBlock.Text)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.AccountNumber,
                view => view.AccountNumberBlock.Text)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.VisibleAccountNumber,
                view => view.AccountNumberBlock.IsEnabled)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.VisibleAccountNumber,
                view => view.AccountNumberLabel.IsEnabled)
                .DisposeWith(disposable);
        }

        private void Validation(CompositeDisposable disposable)
        {
            this.BindValidation(this.ViewModel,
                vm => vm.SelectedCardType,
                view => view.TypesError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.SelectedBankCurrency,
                view => view.CurrencysError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.SelectedDivisions,
                view => view.DivisionsError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.SelectedStatus,
                view => view.StatusesError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.SelectedINN,
                view => view.INNError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.InsuranceNumber,
                view => view.InsuranceNumberError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.VisibleAccountNumber,
                view => view.AccountNumberError.Content)
                .DisposeWith(disposable);
        }

    }
}
