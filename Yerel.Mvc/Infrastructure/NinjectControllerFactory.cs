using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;
using Yerel.Business.Infrastructure.Ninject;

namespace Yerel.Mvc.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;
        public NinjectControllerFactory()
        {
            var soa = Convert.ToBoolean(ConfigurationManager.AppSettings["SOA"]);

            //_kernel = new StandardKernel(new BusinessModule());
            _kernel = new StandardKernel(soa ? (INinjectModule)new ServiceModule() : new BusinessModule());
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)_kernel.Get(controllerType);
        }
    }
}