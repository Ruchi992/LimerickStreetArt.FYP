namespace LimerickStreetArt.Web.Controllers
{
	using LimerickStreetArt;
	using LimerickStreetArt.MySQL;
	using LimerickStreetArt.Repository;
	using LimerickStreetArt.Web.Models;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Configuration;
	using System;

	public class Login : Controller
	{
		private readonly UserAccountRepository userAccountRepository;

		public Login(IConfiguration configuration)
		{
			var databaseClass = new DatabaseClass
			{
				ConnectionString = configuration.GetConnectionString("LocalDatabase"),
			};
			userAccountRepository = new UserAccountRepositoryClass(databaseClass);
		}
		public ActionResult LoggedIn()
		{
			return View();
		}

		public ActionResult Index()
		{
			return View();
		}


		[HttpPost]
		public ActionResult Index(LoginModel model)
		{
			if (ModelState.IsValid)
			{
				var userAccount = userAccountRepository.GetUserAccountByCredentials(model.Username, model.Password);

				if (userAccount != null)
				{
					if (userAccount.Active)
					{
						SettingUserAsLoggedIn(userAccount);
						return RedirectToAction(
							actionName: nameof(StreetArtController.Index),
							controllerName: "StreetArt"
							);
					}
					else
					{
						ModelState.AddModelError("", "Your Account has been locked.  Please contact an Administrator");
					}
				}
				else
				{
					ModelState.AddModelError("", "Invalid login attempt");
				}
			}
			else
			{
				ModelState.AddModelError("", "Invalid user inputs");
			}
			return View(model);
		}

		private void SettingUserAsLoggedIn(UserAccount userAccount)
		{
			//	TODO user identify manager or session to save userAccount.Id
		}
	}

}