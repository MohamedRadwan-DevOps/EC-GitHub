using System.Web.Security;
using Codeflyers.EC.MVC.Abstract;

namespace Codeflyers.EC.MVC.Infrastructure.Concrete
{
    public class FormAuthenticationProvider : IAuthenticationProvider
    {
        public bool Authenticate(string userName, string password)
        {
            bool result = FormsAuthentication.Authenticate(userName, password);
            //bool result = Membership.ValidateUser(userName, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(userName, false);
            }
            return result;
        }
    }
}