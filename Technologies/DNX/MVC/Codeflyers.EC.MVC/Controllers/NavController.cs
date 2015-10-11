using System.Collections.Generic;
using Codeflyers.EC.Domain.Abstract;
using Microsoft.AspNet.Mvc;
using System.Linq;

namespace Codeflyers.EC.MVC.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository _productRepository;

        public NavController(IProductRepository repository)
        {
            _productRepository = repository;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = _productRepository.GetAll().Select(x => x.Category).Distinct().OrderBy(x => x);
            return PartialView(categories);
        }

    }
}
