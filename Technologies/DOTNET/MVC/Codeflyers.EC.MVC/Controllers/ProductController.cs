using System.Linq;
using System.Web.Mvc;
using Codeflyers.EC.Domain.Abstract;
using Codeflyers.EC.Domain.Entities;
using Codeflyers.EC.MVC.Infrastructure;
using Codeflyers.EC.MVC.Models;

namespace Codeflyers.EC.MVC.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public int MainAreaHomePageSize { get; set; } = 3;
        public int SubAreaHomePageSize { get; set; } = 1;
        public int InternalPageSize { get; set; } = 9;

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
                .Skip((page - 1) * InternalPageSize)
                .Take(InternalPageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = InternalPageSize,
                    TotalItems = (category == null) ? _repository.GetAll().Count() : _repository.GetAll().Count(e => e.Category == category)
                },
                CurrentCategory = category
            };
            return View(productListViewModel);

        }
        public ViewResult Items(string category, int page = 1)
        {
            ProductItemsViewModel productItemsViewModel = new ProductItemsViewModel
            {
                FeaturedProducts = _repository.GetAll()
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * MainAreaHomePageSize)
                .Take(MainAreaHomePageSize),
                FeaturedProductsPagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = MainAreaHomePageSize,
                    TotalItems = (category == null) ? _repository.GetAll().Count() : _repository.GetAll().Count(e => e.Category == category)
                },

                NewArrivalProducts = _repository.GetAll()
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * MainAreaHomePageSize)
                .Take(MainAreaHomePageSize),
                NewArrivalProductsPagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = MainAreaHomePageSize,
                    TotalItems = (category == null) ? _repository.GetAll().Count() : _repository.GetAll().Count(e => e.Category == category)
                },

                RandomProducts = _repository.GetAll()
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * SubAreaHomePageSize)
                .Take(SubAreaHomePageSize),
                RandomProductsPagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = SubAreaHomePageSize,
                    TotalItems = (category == null) ? _repository.GetAll().Count() : _repository.GetAll().Count(e => e.Category == category)
                },
                BestSellerProducts = _repository.GetAll()
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * SubAreaHomePageSize)
                .Take(SubAreaHomePageSize),
                BestSellerProductsPagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = SubAreaHomePageSize,
                    TotalItems = (category == null) ? _repository.GetAll().Count() : _repository.GetAll().Count(e => e.Category == category)
                },
                HotSaleProducts = _repository.GetAll()
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * SubAreaHomePageSize)
                .Take(SubAreaHomePageSize),
                HotSaleProductsPagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = SubAreaHomePageSize,
                    TotalItems = (category == null) ? _repository.GetAll().Count() : _repository.GetAll().Count(e => e.Category == category)
                },
                
                CurrentCategory = category
            };
            return View(productItemsViewModel);

        }
        public FileContentResult GetImage(int productId)
        {
            Product product = _repository.GetAll().FirstOrDefault(p => p.ProductId == productId);
            if (product!=null)
            {
                FileContentResult image=new FileContentResult(product.ImageData,product.ImageMimeType);
                return image;
            }
            return null;
        }
    }
}
