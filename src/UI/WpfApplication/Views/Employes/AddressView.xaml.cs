using Metcom.CardPay3.WpfApplication.ViewModels.Employes;
using ReactiveUI;
using Splat;
using System;

namespace Metcom.CardPay3.WpfApplication.Views.Employes
{
    /// <summary>
    /// Логика взаимодействия для AddAddressView.xaml
    /// </summary>
    public partial class AddressView
    {
        public AddressView(AddressViewModel viewModel = null)
        {
            ViewModel = viewModel ?? Locator.Current.GetService<AddressViewModel>();
            DataContext = ViewModel;

            InitializeComponent();

            this.WhenActivated(disposable =>
            {

            });
        }
    }
}
