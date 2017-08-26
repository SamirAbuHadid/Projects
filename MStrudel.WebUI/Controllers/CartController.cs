using MStrudel.Domain.Abstract;
using MStrudel.Domain.Entities;
using MStrudel.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace MStrudel.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductsRepository _productRepository;

        public CartController(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartListViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = _productRepository.Products.FirstOrDefault(p => p.ProductID == productId);
            if(product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = _productRepository.Products.FirstOrDefault(p => p.ProductID == productId);
            if(product != null)
            {
                cart.DeleteItem(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult ChangeQuantity(Cart cart, int productId, int quantity)
        {
            Product product = _productRepository.Products.FirstOrDefault(p => p.ProductID == productId);
            if(product != null)
            {
                cart.ChangeQuantity(product, quantity);
            }

            return RedirectToAction("Index");
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}
