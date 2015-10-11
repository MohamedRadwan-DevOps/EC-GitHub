using System;
using System.Web.Mvc;
using System.Web.Routing;
using Codeflyers.EC.Domain.Abstract;
using Codeflyers.EC.Domain.Concrete;
using Codeflyers.EC.MVC.Abstract;
using Codeflyers.EC.MVC.Infrastructure.Concrete;
using Ninject;

namespace Codeflyers.EC.MVC.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBinding();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBinding()
        {
            ninjectKernel.Bind<IProductRepository>().To<EfProductRepository>();
            ninjectKernel.Bind<IAuthenticationProvider>().To<FormAuthenticationProvider>();
        }
    }
}