using Codeflyers.EC.Domain.Entities;
using FluentValidation;

namespace Codeflyers.EC.Domain.Validators
{
    public class ShippingDetailsValidator:AbstractValidator<ShippingDetails>
    {
        public ShippingDetailsValidator()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("Please enter your name");
            RuleFor(s => s.Address).NotEmpty().WithMessage("Please enter your address");
            RuleFor(s => s.Country).NotEmpty().WithMessage("Please enter your conuntry");
            RuleFor(s => s.City).NotEmpty().WithMessage("Please enter your city");
            RuleFor(s => s.State).NotEmpty().WithMessage("Please enter your state");
        }
    }
}
