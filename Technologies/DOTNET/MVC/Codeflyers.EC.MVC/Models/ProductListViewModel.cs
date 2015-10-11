using System.Collections.Generic;
using Codeflyers.EC.Domain.Entities;

namespace Codeflyers.EC.MVC.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }

    }
}