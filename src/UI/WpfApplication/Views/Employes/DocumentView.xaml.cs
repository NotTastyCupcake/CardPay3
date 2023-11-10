using Metcom.CardPay3.WpfApplication.ViewModels.Employes;
using ReactiveUI;
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

namespace Metcom.CardPay3.WpfApplication.Views.Employes
{
    /// <summary>
    /// Логика взаимодействия для AddAddressView.xaml
    /// </summary>
    public partial class DocumentView
    {
        public DocumentView(DocumentViewModel viewModel = null)
        {
            ViewModel = viewModel ?? Locator.Current.GetService<DocumentViewModel>();
            DataContext = ViewModel;

            InitializeComponent();

        }
    }
}
