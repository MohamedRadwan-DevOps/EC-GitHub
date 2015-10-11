using System.Collections.Generic;
using Codeflyers.EC.Domain.Entities;

namespace Codeflyers.EC.MVC.Models
{
    public class ProductItemsViewModel
    {
        public IEnumerable<Product> FeaturedProducts { get; set; }
        public IEnumerable<Product> NewArrivalProducts { get; set; }
        public IEnumerable<Product> RandomProducts { get; set; }
        public IEnumerable<Product> BestSellerProducts { get; set; }
        public IEnumerable<Product> HotSaleProducts { get; set; }
        public PagingInfo FeaturedProductsPagingInfo { get; set; }
        public PagingInfo NewArrivalProductsPagingInfo { get; set; }
        public PagingInfo RandomProductsPagingInfo { get; set; }
        public PagingInfo BestSellerProductsPagingInfo { get; set; }
        public PagingInfo HotSaleProductsPagingInfo { get; set; }
        public string CurrentCategory { get; set; }

    }
}