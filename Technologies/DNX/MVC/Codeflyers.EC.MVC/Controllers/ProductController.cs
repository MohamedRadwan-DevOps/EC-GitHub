using System.Linq;
using Codeflyers.EC.Domain.Abstract;
using Codeflyers.EC.Domain.Entities;
using Codeflyers.EC.MVC.Infrastructure;
using Codeflyers.EC.MVC.Models;
using Microsoft.AspNet.Mvc;

namespace Codeflyers.EC.MVC.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public int PageSize = 3;

        public ProductController(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductListViewModel productListViewModel = new ProductListViewModel
            {
                Products = _repository.GetAll()
                .Where(p => category == null || p.Category == category)
                .OrderBy(p=> p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = (category == null) ? _repository.GetAll().Count() : _repository.GetAll().Count(e => e.Category == category)
                },
                CurrentCategory = category
            };
            return View(productListViewModel);

        }

        public FileContentResult GetImage(int productId)
        {
            Product product = _repository.GetAll().FirstOrDefault(p => p.ProductId == productId);
            if (product!=null)
            {
                FileContentResult image=new FileContentResult(Uitilties.ObjectToByteArray(product.ImageData),product.ImageMimeType);
                //return File(product.ImageData, product.ImageMimeType);
                return image;
            }
            return null;
        }

    }
}
