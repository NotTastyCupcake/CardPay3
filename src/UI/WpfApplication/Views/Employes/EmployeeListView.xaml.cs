using Metcom.CardPay3.WpfApplication.ViewModels.Employes;
using Splat;
using System;
using System.Windows.Input;

namespace Metcom.CardPay3.WpfApplication.Views.Employes
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

        private void SelectAllExecuted(object sender, ExecutedRoutedEventArgs e)
        {

            if(employeeListView.SelectedItems.Count > 0 )
            {
                employeeListView.UnselectAll();
            }
            else
            {
                employeeListView.SelectAll();
            }
        }
    }
}
