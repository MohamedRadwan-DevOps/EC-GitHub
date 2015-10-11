using Codeflyers.EC.Domain.Validators;
using FluentValidation.Attributes;

namespace Codeflyers.EC.Domain.Entities
{
    [Validator(typeof(ShippingDetailsValidator))]
    public class ShippingDetails
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public bool GiftWrap { get; set; }
    }
}
