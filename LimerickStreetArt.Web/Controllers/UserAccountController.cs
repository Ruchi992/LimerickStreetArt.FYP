namespace LimerickStreetArt.Web.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using LimerickStreetArt.MySQL;
	using LimerickStreetArt.Repository;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Configuration;

	public class UserAccountController : Controller
	{
		private readonly UserAccountRepository userAccountRepository;
		public UserAccountController(IConfiguration configuration)
		{
			var databaseClass = new DatabaseClass
			{
				ConnectionString = configuration.GetConnectionString("LocalDatabase"),
			};
			userAccountRepository = new UserAccountRepositoryClass(databaseClass);
		}

		// GET: UserAccount
		public ActionResult Index()
		{
			List<UserAccount> userAccounts = userAccountRepository.GetUserAccounts();
			return View(userAccounts);
		}

		// GET: UserAccount/Details/5
		public ActionResult Details(int id)
		{
			UserAccount userAccount = userAccountRepository.GetById(id);
			return View(userAccount);
		}

		// GET: UserAccount/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: UserAccount/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: UserAccount/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: UserAccount/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: UserAccount/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: UserAccount/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}