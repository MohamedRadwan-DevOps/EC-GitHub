using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Codeflyers.EC.Domain.Entities;
using Codeflyers.EC.MVC.Binders;
using Codeflyers.EC.MVC.Infrastructure;
using FluentValidation.Mvc;

namespace Codeflyers.EC.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
            FluentValidationModelValidatorProvider.Configure();
        }
    }
}
