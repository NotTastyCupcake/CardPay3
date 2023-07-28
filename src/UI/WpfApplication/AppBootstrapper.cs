using Metcom.CardPay3.ApplicationCore.Interfaces;
using Metcom.CardPay3.Infrastructure.Data;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.WpfApplication
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        public RoutingState Router { get; private set; }

        public AppBootstrapper()
        {
            // View "StackTrace"
            Router = new RoutingState();

            //// This is our main window host
            //Locator.CurrentMutable.RegisterLazySingleton(() => this, typeof(IScreen));

            //// Repositories
            //Locator.CurrentMutable.Register(() => typeof(EfRepository<>), typeof(IRepository<>));




        }


    }
}
