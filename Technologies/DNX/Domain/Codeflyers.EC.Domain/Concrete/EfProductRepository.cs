using System;
using System.Linq;
using System.Linq.Expressions;
using Codeflyers.EC.Domain.Abstract;
using Codeflyers.EC.Domain.Entities;

namespace Codeflyers.EC.Domain.Concrete
{
    public class EfProductRepository : IProductRepository
    {
        private EfDbContext _efDbContext = new EfDbContext();
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public Product AddOrUpdate(Product entity)
        {
            Product product;
            if (entity.ProductId == 0)
            {
                product = _efDbContext.Products.Add(entity);
            }
            else
            {
                product = _efDbContext.Products.Find(entity.ProductId);
                product.Code = entity.Code;
                product.Title = entity.Title;
                product.Description = entity.Description;
                product.Category = entity.Category;
                product.Brand = entity.Brand;
                product.Brand = entity.Brand;
                product.RewardPoints = entity.RewardPoints;
                product.Price = entity.Price;

            }
            Save();
            return product;
        }

        public Product GetByCode(string code)
        {
            throw new NotImplementedException();
        }

        public Product GetById(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetAll()
        {
            return _efDbContext.Products;
        }

        public IQueryable<Product> GetMany(Expression<Func<Product, bool>> @where)
        {
            return _efDbContext.Products.Where(@where);
        }

        public Product Remove(int id)
        {
            var book = _efDbContext.Products.Find(id);
            if (book != null)
            {
                _efDbContext.Products.Remove(book);
                Save();
                return book;
            }
            return null;
        }

        public Product Remove(Product obj)
        {
            if (obj != null)
            {
                var retrivedBook = _efDbContext.Products.Find(obj.ProductId);
                return Remove(retrivedBook.ProductId);
            }
            throw new ArgumentNullException("obj","The obj can't be null");
        }

        public Product Remove(Expression<Func<Product, bool>> @where)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _efDbContext.SaveChanges();
        }
    }
}
