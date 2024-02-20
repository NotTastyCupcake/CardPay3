using Metcom.CardPay3.WpfApplication.ViewModels.Employes;
using Metcom.CardPay3.WpfApplication.ViewModels.Employes.DocumentCRUD;
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

namespace Metcom.CardPay3.WpfApplication.Views.Employes
{
    /// <summary>
    /// Логика взаимодействия для CreateDocumentView.xaml
    /// </summary>
    public partial class CreateDocumentView
    {
        public CreateDocumentView( CreateDocumentViewModel viewModel = null )
        {
            ViewModel = viewModel ?? Locator.Current.GetService<CreateDocumentViewModel>();
            DataContext = ViewModel;
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.OneWayBind(this.ViewModel,
                    vm => vm.Types,
                    view => view.TypesComboBox.ItemsSource)
                    .DisposeWith(disposable);

                BindModel(disposable);

                Validation(disposable);

                this.BindCommand(this.ViewModel,
                    vm => vm.CreateCommand,
                    view => view.Create)
                    .DisposeWith(disposable);

            });
        }

        private void BindModel(CompositeDisposable disposable)
        {
            this.Bind(this.ViewModel,
                vm => vm.SelectedType,
                view => view.TypesComboBox.SelectedItem)
                .DisposeWith(disposable);


            this.Bind(this.ViewModel,
                vm => vm.Series,
                view => view.SeriesBlock.Text)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.Number,
                view => view.NumberBlock.Text)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.SelectedDataIssued,
                view => view.DateIssuedPicker.SelectedDate)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.IssuedBy,
                view => view.IssuedByBlock.Text)
                .DisposeWith(disposable);

            this.Bind(this.ViewModel,
                vm => vm.SubdivisionCode,
                view => view.SubdivisionCodeBlock.Text)
                .DisposeWith(disposable);
        }

        private void Validation(CompositeDisposable disposable)
        {
            this.BindValidation(this.ViewModel,
                vm => vm.SelectedType,
                view => view.TypesError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.Series,
                view => view.SeriesError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.Number,
                view => view.NumberError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.SelectedDataIssued,
                view => view.DateIssuedError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.IssuedBy,
                view => view.IssuedByError.Content)
                .DisposeWith(disposable);

            this.BindValidation(this.ViewModel,
                vm => vm.SubdivisionCode,
                view => view.SubdivisionCodeError.Content)
                .DisposeWith(disposable);
        }
    }
}
