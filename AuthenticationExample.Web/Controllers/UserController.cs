﻿using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppHarbor.Web.Security;
using AuthenticationExample.Castle.Web.ViewModels;
using AuthenticationExample.Castle.Web.Model;
using AuthenticationExample.Castle.Web.PersistenceSupport;  

namespace AuthenticationExample.Castle.Web.Controllers
{
	public class UserController : Controller
    {
        private readonly IAuthenticator _authenticator;
        private readonly IRepository _repository;

        public UserController(IAuthenticator authenticator, IRepository  repository)
        {
            _authenticator = authenticator;
            _repository = repository;
		}

		[HttpGet]
		public ActionResult New()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(UserInputModel userInputModel)
		{
			if (_repository.GetAll<User>().Any(x => x.Username == userInputModel.Username))
			{
				ModelState.AddModelError("Username", "Username is already in use");
			}

			if (ModelState.IsValid)
			{
				var user = new User
				{
					Id = Guid.NewGuid(),
					Username = userInputModel.Username,
					Password = HashPassword(userInputModel.Password),
				};

				_repository.SaveOrUpdate(user);

				_authenticator.SetCookie(user.Username);

				return RedirectToAction("Index", "Home");
			}

			return View("New", userInputModel);
		}

		[HttpGet]
		[Authorize]
		public ActionResult Show()
		{
			var user = _repository.GetAll<User>().SingleOrDefault(x => x.Username == User.Identity.Name);
			if (user == null)
			{
				throw new HttpException(404, "Not found");
			}

			return View(user);
		}

		private static string HashPassword(string value)
		{
			string salt = BCrypt.Net.BCrypt.GenerateSalt();
			return BCrypt.Net.BCrypt.HashPassword(value, salt);
		}
	}
}
