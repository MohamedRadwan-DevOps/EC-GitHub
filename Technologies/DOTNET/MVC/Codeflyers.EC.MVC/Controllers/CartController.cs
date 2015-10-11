using Codeflyers.EC.Domain.Abstract;
using Codeflyers.EC.Domain.Entities;
using Codeflyers.EC.MVC.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

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
        public RedirectResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            var product = _productRepository.GetAll().FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return Redirect(returnUrl);
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            var product = _productRepository.GetAll().FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.RemoveItem(product);
            }
            return RedirectToAction("Index", new { returnUrl });

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
