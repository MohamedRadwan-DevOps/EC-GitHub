using System.Threading.Tasks;
using System.Web.Mvc;
using Codeflyers.EC.Domain.Entities;
using Codeflyers.EC.MVC.Infrastructure;
using System.Web.Mvc;
namespace Codeflyers.EC.MVC.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string SessionKey = "cart";


        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var cart = controllerContext.HttpContext.Session[SessionKey];
            if (cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session[SessionKey] = cart;
            }
            return cart;
        }

       
    }
}
