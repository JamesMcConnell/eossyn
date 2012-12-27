﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Eossyn.Web.Models;
using Eossyn.Infrastructure.Services;

namespace Eossyn.Web.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		private IUserService _userService;

		public AccountController(IUserService userService)
		{
			_userService = userService;
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
			if (ModelState.IsValid && _userService.ValidateLogin(model.UserName, model.Password))
			{
				_userService.SignIn(model.UserName, string.Empty, model.RememberMe, DateTime.Now.AddMonths(1));
				return RedirectToLocal(returnUrl);
			}

			// If we got this far, something failed, redisplay form
			ModelState.AddModelError("", "The user name or password provided is incorrect.");
			return View(model);
		}

		// GET: /Account/Logout
		public ActionResult Logout()
		{
			_userService.SignOut();
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
			if (ModelState.IsValid && _userService.ValidateRegistration(model.UserName, model.EmailAddress))
			{
				_userService.CreateUser(model.UserName, model.EmailAddress, model.Password);
				_userService.SignIn(model.UserName, string.Empty, false, DateTime.Now.AddMonths(1));
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
