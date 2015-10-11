using System.Web.Mvc;
using Codeflyers.EC.MVC.Abstract;
using Codeflyers.EC.MVC.Models;

namespace Codeflyers.EC.MVC.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationProvider _authenticationProvider;

        public AccountController(IAuthenticationProvider authenticationProvider)
        {
            _authenticationProvider = authenticationProvider;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                bool authenticated = _authenticationProvider.Authenticate(loginViewModel.UserName, loginViewModel.Password);

                if (authenticated)
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                ModelState.AddModelError("login", "Incorrect username or password");
                TempData["message"] = "Incorrect username or password";
                return View();
            }
            return View();
        }
    }
}
