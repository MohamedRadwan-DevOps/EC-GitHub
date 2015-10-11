using Codeflyers.EC.Domain.Entities;
using FluentValidation;

namespace Codeflyers.EC.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(p =>p.Name).NotEmpty().WithMessage("Please enter yoru name");
            RuleFor(p => p.UserName).NotEmpty().WithMessage("Please enter your user name");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Please enter yoru password");
        }
    }
}