namespace Codeflyers.EC.MVC.Infrastructure.Abstract
{
    public interface IAuthenticationProvider
    {
        bool Authenticate(string userName, string password);
    }
}
