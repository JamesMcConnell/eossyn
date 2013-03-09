using System;
using System.Web.Mvc;
using Eossyn.Infrastructure.Managers;
using Eossyn.Web.Models;
using NServiceBus;
using Eossyn.Data.Repositories;
using Eossyn.Models;
using System.Web.Configuration;
using System.Configuration;

namespace Eossyn.Web.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
        private IUserManager _userManager;
        private IUserSessionManager _userSessionManager;
        private IUserSettingRepository _userSettingRepo;
        //public IBus Bus { get; set; }

		public AccountController(IUserManager userManager, IUserSessionManager userSessionManager, IUserSettingRepository userSettingRepo)
		{
			_userManager = userManager;
            _userSessionManager = userSessionManager;
            _userSettingRepo = userSettingRepo;
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
            _userManager.SignIn(user.UserName, false);
            
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
				_userManager.SignIn(model.UserName, false);
				return RedirectToAction("Index", "Home");
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

        [Authorize]
        public int GetUserTimeout()
        {
            return int.Parse(((SessionStateSection)ConfigurationManager.GetSection("system.web/sessionState")).Timeout.TotalMilliseconds.ToString());
        }

        [Authorize]
        public void ExtendSession()
        {
            // Don't need to do anything here, just hit the server to extend the session.
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
