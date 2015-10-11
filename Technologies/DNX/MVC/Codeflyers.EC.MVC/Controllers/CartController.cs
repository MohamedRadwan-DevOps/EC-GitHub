using Codeflyers.EC.Domain.Abstract;
using Codeflyers.EC.Domain.Entities;
using Codeflyers.EC.MVC.Models;
using Microsoft.AspNet.Mvc;
using System.Linq;

namespace Codeflyers.EC.MVC.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _productRepository;

        public CartController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            var book = _productRepository.GetAll().FirstOrDefault(p => p.ProductId == productId);
            if (book != null)
            {
                cart.AddItem(book, 1);
            }
            RedirectToRouteResult routeResult = new RedirectToRouteResult("Index", new {returnUrl});
            return routeResult;
        }


        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            var product = _productRepository.GetAll().FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.RemoveItem(product);
            }
            RedirectToRouteResult routeResult = new RedirectToRouteResult("Index", new { returnUrl });
            return routeResult;

        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (!cart.Lines.Any())
            {
                ModelState.AddModelError("EmptyCart", "Your shopping cart is empty!");
            }
            if (ModelState.IsValid)
            {
                cart.Clear();
                return View("Thanks");
            }
            return View(shippingDetails);
        }
    }
}
