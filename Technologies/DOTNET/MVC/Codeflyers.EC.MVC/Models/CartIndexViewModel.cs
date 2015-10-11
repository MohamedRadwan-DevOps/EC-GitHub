using Codeflyers.EC.Domain.Entities;

namespace Codeflyers.EC.MVC.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}