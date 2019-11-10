using MStrudel.Domain.Entities;
using System.Web.Mvc;

namespace MStrudel.WebUI.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private readonly static string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // get the Cart from the session 
            Cart cart = null;
            if(controllerContext.HttpContext.Session != null)
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            
            // create the Cart if there wasn't one in the session data            
            if(cart == null)
            {
                cart = new Cart();
                if(controllerContext.HttpContext.Session != null)
                    controllerContext.HttpContext.Session[sessionKey] = cart;
            }
            // return the cart            
            return cart;
        }
    }
}
