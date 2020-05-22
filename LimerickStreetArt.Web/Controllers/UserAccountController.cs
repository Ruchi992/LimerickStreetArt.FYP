namespace LimerickStreetArt.Web.Controllers
{
	using System.Collections.Generic;
	using AutoMapper;
	using LimerickStreetArt.MySQL;
	using LimerickStreetArt.Repository;
	using LimerickStreetArt.Web.Models;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Configuration;

	public class UserAccountController : Controller
	{
		private readonly IMapper _mapper;
		private readonly UserAccountRepository userAccountRepository;
		public UserAccountController(IConfiguration configuration, IMapper mapper)
		{
			var databaseClass = new DatabaseClass
			{
				ConnectionString = configuration.GetConnectionString("LocalDatabase"),
			};
			userAccountRepository = new UserAccountRepositoryClass(databaseClass);
			_mapper = mapper;
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

			var userAccountModel = _mapper.Map<UserAccountModel>(userAccount);

			return View(userAccountModel);
		}

		// GET: UserAccount/Create
		public ActionResult Create()
		{
			//userAccountRepository.Create(userAccount);
			return View();
		}

		// POST: UserAccount/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(UserAccount userAccount)
		{
			try
			{
				userAccountRepository.Create(userAccount);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(userAccount);
			}
		}

		// GET: UserAccount/Edit/5
		public ActionResult Edit(int id)
		{
			UserAccount userAccount = userAccountRepository.GetById(id);

			var userAccountModel = _mapper.Map<UserAccountModel>(userAccount);


			return View(userAccountModel);
		}

		// POST: UserAccount/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, UserAccountModel userAccountModel)
		{

			//UserAccount userAccount = userAccountRepository.GetById(id);

			UserAccount userAccount = _mapper.Map<UserAccount>(userAccountModel);



			//userAccount.Password = userAccountModel.Password;
			//userAccount.Username = userAccountModel.Username;

			// TODO: Add update logic here

			userAccountRepository.Update(userAccount);

			return RedirectToAction(nameof(Index));

		}

		// GET: UserAccount/Delete/5
		public ActionResult Delete(int id)
		{
			UserAccount userAccount = userAccountRepository.GetById(id);
			return View(userAccount);
		}

		// POST: UserAccount/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				UserAccount userAccount = userAccountRepository.GetById(id);

				userAccount.Password = collection["Password"];
				userAccount.Username = collection["Username"];

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}