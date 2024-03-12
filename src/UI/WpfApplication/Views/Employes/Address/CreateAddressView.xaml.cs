using Metcom.CardPay3.WpfApplication.ViewModels.Employes.AddressCRUD;
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

namespace Metcom.CardPay3.WpfApplication.Views.Employes.Address
{
    /// <summary>
    /// Логика взаимодействия для CreateAddressView.xaml
    /// </summary>
    public partial class CreateAddressView
    {
        public CreateAddressView(CreateAddressViewModel viewModel = null)
        {
            ViewModel = viewModel ?? Locator.Current.GetService<CreateAddressViewModel>();
            DataContext = ViewModel;

            InitializeComponent();


            this.WhenActivated(disposable =>
            {
                this.OneWayBind(this.ViewModel,
                    vm => vm.Types,
                    view => view.TypeComboBox.ItemsSource)
                    .DisposeWith(disposable);

                BindModel(disposable);

                Validation(disposable);

                this.BindCommand(this.ViewModel,
                    vm => vm.CtreateCommand,
                    view => view.CreateButton)
                    .DisposeWith(disposable);

            });

        }

        private void BindModel(CompositeDisposable disposable)
        {
            this.Bind(this.ViewModel,
                vm => vm.SelectedType,
                view => view.TypeComboBox.SelectedItem)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.Postcode,
                view => view.PostcodeBlock.Text)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.CountryName,
                view => view.CountryNameBlock.Text)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.CountryShortName,
                view => view.CountryShortNameBlock.Text)
                .DisposeWith(disposable);


            this.Bind(this.ViewModel,
                vm => vm.CountryCode,
                view => view.CountryCodeBlock.Text)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.StateName,
                view => view.StateBlock.Text)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.District,
                view => view.DistrictBlock.Text)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.CityName,
                view => view.CityNameBlock.Text)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.LocalityName,
                view => view.LocalityNameBlock.Text)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.StreetType,
                view => view.StreetTypeBlock.Text)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.StateName,
                view => view.StreetNameBlock.Text)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.NumHome,
                view => view.NumHomeBlock.Text)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.NumCase,
                view => view.NumCaseBlock.Text)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.NumApartment,
                view => view.NumApartBlock.Text)
                .DisposeWith(disposable);

        }

        private void Validation(CompositeDisposable disposable)
        {
            this.BindValidation(this.ViewModel,
                vm => vm.SelectedType,
                view => view.TypeError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.Postcode,
                view => view.PostCodeError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.CountryName,
                view => view.CountryNameError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.CountryShortName,
                view => view.CountryShortNameError.Content)
                .DisposeWith(disposable);


            this.BindValidation(this.ViewModel,
                vm => vm.CountryCode,
                view => view.CountryCodeError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.StateName,
                view => view.StateError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.District,
                view => view.DistrictError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.CityName,
                view => view.CityNameError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.LocalityName,
                view => view.LocalityNameError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.StreetType,
                view => view.StreetTypeError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.StateName,
                view => view.StreetNameError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.NumHome,
                view => view.NumHomeError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.NumCase,
                view => view.NumCaseError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.NumApartment,
                view => view.NumApartError.Content)
                .DisposeWith(disposable);
        }
    }
}
