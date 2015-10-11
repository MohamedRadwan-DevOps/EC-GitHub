using System.ComponentModel.DataAnnotations;

namespace Codeflyers.EC.MVC.Metadata
{
    public class LoginViewModelMetadata
    {
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}