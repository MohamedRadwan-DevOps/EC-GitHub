using System.Collections.Generic;
using System.Linq;
using Codeflyers.EC.Domain.Abstract;
using Codeflyers.EC.Domain.Entities;
using Codeflyers.EC.MVC.Abstract;

namespace Codeflyers.EC.MVC.Services
{
    public class ProductServices : IProductServices
    {
        private IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Product AddProduct(Product product)
        {
            return _productRepository.AddOrUpdate(product);
        }

        public Product UpdateProduct(Product product)
        {
            return _productRepository.AddOrUpdate(product);
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetById(id);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll().ToList();
        }
    }
}
