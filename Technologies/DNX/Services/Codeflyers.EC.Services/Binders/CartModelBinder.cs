using System.Threading;
using System.Threading.Tasks;
using Codeflyers.EC.Domain.Entities;
using Codeflyers.EC.Services.Infrastructure;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ModelBinding;

namespace Codeflyers.EC.Services.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string SessionKey = "cart";


        public object BindModel(ActionContext actionContext, ModelBindingContext bindingContext)
        {
            var cart = actionContext.HttpContext.Session[SessionKey];
            if (cart == null)
            {
                cart = Uitilties.ObjectToByteArray(new Cart());
                actionContext.HttpContext.Session[SessionKey] = cart;
            }
            return cart;
        }
        public Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
        {
            throw new System.NotImplementedException();
        }

        //public class CartModelBinder : IModelBinder
        //{
        //    private const string SessionKey = "cart";
        //    public Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
        //    {
        //        if (bindingContext.ModelType == typeof(Cart))
        //        {
        //            var model = bindingContext.OperationBindingContext.HttpContext.RequestAborted;
        //            return ModelBindingResult.SuccessAsync(bindingContext.ModelName, model);
        //        }

        //        return ModelBindingResult.NoResultAsync;
        //    }
        //}


        //public class CartModelBinder : IModelBinder
        //{
        //    private const string SessionKey = "cart";
        //    public Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
        //    {

        //        if (bindingContext.ModelType == typeof(Cart))
        //        {
        //            var model = new Cart();


        //            return Task.FromResult(new ModelBindingResult(model, bindingContext.ModelName, true));
        //        }
        //        return Task.FromResult<ModelBindingResult>(null);

        //    }
        //}

    }
}
