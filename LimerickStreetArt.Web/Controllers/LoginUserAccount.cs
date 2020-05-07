using LimerickStreetArt.MySQL;
using LimerickStreetArt.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimerickStreetArt.Web.Controllers
{
	public class LoginUserAccount
	{
		private readonly UserAccountRepository userAccountRepository;
		private object userAccounts;

		public LoginUserAccount(IConfiguration configuration)
		{
			var databaseClass = new DatabaseClass
			{
				ConnectionString = configuration.GetConnectionString("LocalDatabase"),
			};
			userAccountRepository = new UserAccountRepositoryClass(databaseClass);
		}
		public ActionResult Index()
		{
			return View(userAccounts);
		}

		private ActionResult View(Object userAccounts)
		{
			throw new NotImplementedException();
		}
	}
}
