namespace Codeflyers.EC.MVC.Abstract
{
    public interface IAuthenticationProvider
    {
        bool Authenticate(string userName, string password);
    }
}
