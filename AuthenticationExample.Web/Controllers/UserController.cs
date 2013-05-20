using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppHarbor.Web.Security;
using Auth.Enitity; 
using AuthenticationExample.Web.ViewModels;
using Auth.Business;

namespace AuthenticationExample.Web.Controllers
{
	public class UserController : Controller
	{
		private readonly IAuthenticator _authenticator;
		private readonly IAccountService _accountService;

        public UserController(IAuthenticator authenticator, IAccountService accountService)
		{
			_authenticator = authenticator;
            _accountService = accountService;
		}

		[HttpGet]
		public ActionResult New()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(UserInputModel userInputModel)
		{
            if (_accountService.GetByUsername(userInputModel.Username) != null)
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

				_accountService.SaveOrUpdate(user);

				_authenticator.SetCookie(user.Username);

				return RedirectToAction("Index", "Home");
			}

			return View("New", userInputModel);
		}

		[HttpGet]
		[Authorize]
		public ActionResult Show()
		{
			var user = _accountService.GetByUsername(User.Identity.Name);  
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
