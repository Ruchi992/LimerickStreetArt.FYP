using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimerickStreetArt.MySQL;
using LimerickStreetArt.Repository;
using LimerickStreetArt.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LimerickStreetArt.Web.Controllers
{
	public class RegisterationController : Controller
	{
		private readonly UserAccountRepository userAccountRepository;

		public RegisterationController(IConfiguration configuration)
		{
			var databaseClass = new DatabaseClass
			{
				ConnectionString = configuration.GetConnectionString("LocalDatabase"),
			};
			userAccountRepository = new UserAccountRepositoryClass(databaseClass);
		}

		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Index(RegistrationModel registrationModel)
		{
			if (ModelState.IsValid)
			{
				bool passwordsDoNotMatch = registrationModel.Password != registrationModel.ReconformPassword;
				bool usernameIsTaken = false;
				bool emailIsInUse = false;

				if (usernameIsTaken)
				{
					ModelState.AddModelError("", "Usernme is already In use.");
				}
				if (emailIsInUse)
				{
					ModelState.AddModelError("", "e-mail is already In use.");
				}
				if (passwordsDoNotMatch)
				{
					ModelState.AddModelError("", "Passwords don't match.");
				}

				if (!usernameIsTaken && !emailIsInUse && !passwordsDoNotMatch)
				{
					var userAccount = new UserAccount
					{
						AccessLevel = 2,
						Active = true,
						DateOfBirth = registrationModel.DateOfBirth,
						Email = registrationModel.Email,
						Password = registrationModel.Password,
						Username = registrationModel.Username,
					};
					userAccountRepository.Create(userAccount);

					var loginModel = new LoginModel { Username = registrationModel.Username };

					return RedirectToAction("Index", "Login", loginModel);
				}
				else
				{
					return View(registrationModel);
				}
			}
			else
			{
				return View(registrationModel);
			}
		}
	}
}