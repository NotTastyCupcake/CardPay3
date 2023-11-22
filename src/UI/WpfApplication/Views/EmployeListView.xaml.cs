using Metcom.CardPay3.WpfApplication.ViewModels;
using Splat;
using System;

namespace Metcom.CardPay3.WpfApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployeListView.xaml
    /// </summary>
    public partial class EmployeListView
    {
        public EmployeListView(EmployeeListViewModel viewModel = null)
        {
            ViewModel = viewModel ?? Locator.Current.GetService<EmployeeListViewModel>();
            DataContext = ViewModel;

            InitializeComponent();
        }
    }
}
