using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codeflyers.EC.Domain.Entities;

namespace Codeflyers.EC.MVC.Models
{
    public class ProductSummaryViewModel
    {
        public Product Product { get; set; }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
