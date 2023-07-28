using DynamicData;
using Metcom.CardPay3.ApplicationCore.Entities;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Subjects;
using System.Security;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;

namespace Metcom.CardPay3.WpfApplication.ViewModels;
public class HomeViewModel : ReactiveObject, IScreen
{
    public RoutingState Router { get; }

    public ObservableCollection<Organization> Organizations { get; set; }
    public Organization Organization { get; set; }

    public ReactiveCommand<Organization, Window> Employes;
    public HomeViewModel()
    {
        Router = new RoutingState();

        Organizations = new ObservableCollection<Organization>
            {
                new Organization("Test Organization")
            };
    }
}