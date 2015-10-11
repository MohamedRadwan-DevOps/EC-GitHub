using Codeflyers.EC.Domain.Entities;
using FluentValidation;

namespace Codeflyers.EC.Domain.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("Please enter the product title");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Please enter the product description");
            RuleFor(p => p.Price).NotEmpty().WithMessage("Please enter the product Price");
        }
    }
}

