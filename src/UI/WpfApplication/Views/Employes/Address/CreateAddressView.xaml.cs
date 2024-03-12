using Metcom.CardPay3.WpfApplication.ViewModels.Employes.AddressCRUD;
using Splat;
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
        }
    }
}
