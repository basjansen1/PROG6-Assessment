using Hotel_Tamagotchi.Models;
using Hotel_Tamagotchi.Models.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace Hotel_Tamagotchi.Controllers
{
    public class NinjectControllerFactory : IControllerFactory
    {
        private StandardKernel _kernel;
        public NinjectControllerFactory()
        {
            _kernel = new StandardKernel();
            Load();
        }

        public void Load()
        {
            // Binding models
            _kernel.Bind<Hotel_TamagotchiContext>().ToSelf();
            _kernel.Bind<RoomRepository>().ToSelf();
            _kernel.Bind<TamagotchiRepository>().ToSelf();

            // Binding controllers
            _kernel.Bind<IController>().To<HomeController>();
            _kernel.Bind<IController>().To<RoomsController>();
            _kernel.Bind<IController>().To<TamagotchisController>();
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName == "Tamagotchis")
                return _kernel.Get<TamagotchisController>();
            return null;
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