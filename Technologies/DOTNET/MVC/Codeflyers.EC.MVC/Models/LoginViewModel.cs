using System.ComponentModel.DataAnnotations;
using Codeflyers.EC.MVC.Metadata;
using Codeflyers.EC.MVC.Validators;
using FluentValidation.Attributes;

namespace Codeflyers.EC.MVC.Models
{
    [Validator(typeof(LoginViewModelValidator))]
    [MetadataType(typeof(LoginViewModelMetadata))]
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}