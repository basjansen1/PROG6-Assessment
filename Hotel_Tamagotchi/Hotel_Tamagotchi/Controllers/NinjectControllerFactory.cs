using Hotel_Tamagotchi.Helpers;
using Hotel_Tamagotchi.Models;
using Hotel_Tamagotchi.Models.Repositories;
using Hotel_Tamagotchi.Models.ViewModels;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace Hotel_Tamagotchi.Controllers
{
    public class NinjectControllerFactory : NinjectModule, IControllerFactory
    {
        private StandardKernel _kernel;
        public NinjectControllerFactory()
        {
            _kernel = new StandardKernel();
            Load();
        }

        public override void Load()
        {
            // Binding models
            _kernel.Bind<Hotel_TamagotchiContext>().ToSelf();
            _kernel.Bind<IRoomRepository>().To<RoomRepository>();
            _kernel.Bind<ITamagotchiRepository>().To<TamagotchiRepository>();
            _kernel.Bind<RoomViewModel>().ToSelf().InSingletonScope();

            // Binding controllers
            _kernel.Bind<IController>().To<HomeController>();
            _kernel.Bind<IController>().To<RoomsController>();
            _kernel.Bind<IController>().To<TamagotchisController>();
            _kernel.Bind<IController>().To<ReservationController>();
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            switch(controllerName)
            {
                case "Tamagotchis":
                    return _kernel.Get<TamagotchisController>();
                case "Rooms":
                    return _kernel.Get<RoomsController>();
                case "Reservation":
                    return _kernel.Get<ReservationController>();
                default:
                    return _kernel.Get<TamagotchisController>();
            }
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;

            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}