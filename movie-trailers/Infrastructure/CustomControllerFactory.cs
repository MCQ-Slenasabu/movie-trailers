using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using movie_trailers.BLL.Services;
using movie_trailers.Controllers;

namespace movie_trailers.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName.ToLower().StartsWith("movie"))
            {
                var service = new TrailerService();
                var controller = new MovieController(service);
                return controller;
            }

            var defaultFactory = new DefaultControllerFactory();
            return defaultFactory.CreateController(requestContext, controllerName);
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