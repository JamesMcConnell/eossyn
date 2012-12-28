using System;
using System.Web.Mvc;
using Eossyn.Infrastructure.Managers;
using Eossyn.Web.Models;

namespace Eossyn.Web.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		private IUserManager _userManager;
        private IUserSessionManager _userSessionManager;

		public AccountController(IUserManager userManager, IUserSessionManager userSessionManager)
		{
			_userManager = userManager;
            _userSessionManager = userSessionManager;
		}

		// GET: /Account/Login
		[AllowAnonymous]
		public ActionResult Login(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		// POST: /Account/Login
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginModel model, string returnUrl)
		{
            // First, verify our model is valid.
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(model);
            }

            var user = _userManager.FetchUserByUserName(model.UserName);
            // Does the user even exist?
            if (user == null)
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(model);
            }

            // Can the user actually login?
            if (!_userManager.ValidateLogin(model.UserName, model.Password))
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(model);
            }

            // Is the user still logged in with another browser?
            if (_userSessionManager.UserSessionExists(user.UserId))
            {
                ModelState.AddModelError("", "There is already an active session for this user.");
                return View(model);
            }

			// If we got this far, we're good to go.
            _userManager.SignIn(user.UserName, string.Empty, model.RememberMe, DateTime.Now.AddMonths(1));
            _userSessionManager.CreateUserSession(user.UserId, Guid.Empty, Guid.Empty);
            return RedirectToLocal(returnUrl);
		}

		// GET: /Account/Logout
		public ActionResult Logout()
		{
			_userManager.SignOut();
            _userSessionManager.EndUserSession();
			return RedirectToAction("Index", "Home");
		}

		// GET: /Account/Register
		[AllowAnonymous]
		public ActionResult Register()
		{
			return View();
		}

		// POST: /Account/Register
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Register(RegisterModel model)
		{
			if (ModelState.IsValid && _userManager.ValidateRegistration(model.UserName, model.EmailAddress))
			{
				_userManager.CreateUser(model.UserName, model.EmailAddress, model.Password);
				_userManager.SignIn(model.UserName, string.Empty, false, DateTime.Now.AddMonths(1));
				return RedirectToAction("Index", "Home");
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		#region Helpers
		private ActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}
		#endregion
	}
}
