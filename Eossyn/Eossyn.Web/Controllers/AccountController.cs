using System;
using System.Web.Mvc;
using Eossyn.Infrastructure.Managers;
using Eossyn.Web.Models;
using NServiceBus;

namespace Eossyn.Web.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
        public IUserManager UserManager { get; set; }
        public IUserSessionManager UserSessionManager { get; set; }
        //public IBus Bus { get; set; }

		public AccountController(IUserManager userManager, IUserSessionManager userSessionManager)
		{
			UserManager = userManager;
            UserSessionManager = userSessionManager;
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

            var user = UserManager.FetchUserByUserName(model.UserName);
            // Does the user even exist?
            if (user == null)
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(model);
            }

            // Can the user actually login?
            if (!UserManager.ValidateLogin(model.UserName, model.Password))
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(model);
            }

            // Is the user still logged in with another browser?
            //if (UserSessionManager.UserSessionExists(user.UserId))
            //{
            //    ModelState.AddModelError("", "There is already an active session for this user.");
            //    return View(model);
            //}

			// If we got this far, we're good to go.
            UserManager.SignIn(user.UserName, string.Empty, false, DateTime.Now.AddMonths(1));
            UserSessionManager.CreateUserSession(user.UserId, Guid.Empty, Guid.Empty);
            return RedirectToLocal(returnUrl);
		}

		// GET: /Account/Logout
		public ActionResult Logout()
		{
			UserManager.SignOut();
            UserSessionManager.EndUserSession();
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
			if (ModelState.IsValid && UserManager.ValidateRegistration(model.UserName, model.EmailAddress))
			{
				UserManager.CreateUser(model.UserName, model.EmailAddress, model.Password);
				UserManager.SignIn(model.UserName, string.Empty, false, DateTime.Now.AddMonths(1));
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
