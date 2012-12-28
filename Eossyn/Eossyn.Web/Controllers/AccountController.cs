using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Eossyn.Web.Models;
using Eossyn.Infrastructure.Managers;

namespace Eossyn.Web.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		private IUserManager _userManager;

		public AccountController(IUserManager userManager)
		{
			_userManager = userManager;
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
			if (ModelState.IsValid && _userManager.ValidateLogin(model.UserName, model.Password))
			{
				_userManager.SignIn(model.UserName, string.Empty, model.RememberMe, DateTime.Now.AddMonths(1));
				return RedirectToLocal(returnUrl);
			}

			// If we got this far, something failed, redisplay form
			ModelState.AddModelError("", "The user name or password provided is incorrect.");
			return View(model);
		}

		// GET: /Account/Logout
		public ActionResult Logout()
		{
			_userManager.SignOut();
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
