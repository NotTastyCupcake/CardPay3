using Metcom.CardPay3.WpfApplication.ViewModels.Employes;
using Splat;
using System;

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
