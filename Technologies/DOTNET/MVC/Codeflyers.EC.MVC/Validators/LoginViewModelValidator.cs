using Codeflyers.EC.MVC.Models;
using FluentValidation;

namespace Codeflyers.EC.MVC.Validators
{
    public class LoginViewModelValidator:AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Please Enter the user name");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please Enter the passowrd");
        }
    }
}