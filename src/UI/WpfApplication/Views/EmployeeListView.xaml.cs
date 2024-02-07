using Metcom.CardPay3.WpfApplication.ViewModels.Employes;
using Splat;
using System;

namespace Metcom.CardPay3.WpfApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployeListView.xaml
    /// </summary>
    public partial class EmployeeListView
    {
        public EmployeeListView(EmployeeListViewModel viewModel = null)
        {
            ViewModel = viewModel ?? Locator.Current.GetService<EmployeeListViewModel>();
            DataContext = ViewModel;

            InitializeComponent();
        }
    }
}
