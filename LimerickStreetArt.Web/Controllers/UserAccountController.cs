namespace LimerickStreetArt.Web.Controllers
{
	using System.Collections.Generic;
	using AutoMapper;
	//using LimerickStreetArt.SQLite;
	using LimerickStreetArt.MySQL;
	using LimerickStreetArt.Repository;
	using LimerickStreetArt.Web.Models;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Configuration;

	public class UserAccountController : Controller
	{
		#region Private Fiedls
		private readonly IMapper _mapper;
		private readonly UserAccountRepository userAccountRepository;
		#endregion
		public UserAccountController(IConfiguration configuration, IMapper mapper)
		{
			var databaseClass = new DatabaseClass
			{
				ConnectionString = configuration.GetConnectionString("LocalDatabase"),
			};
			userAccountRepository = new UserAccountRepositoryClass(databaseClass);
			_mapper = mapper;
		}
		#region Public Methods
		#endregion
		public ActionResult Create()
		{
			return View();
		}
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
		public ActionResult Details(int id)
		{
			UserAccount userAccount = userAccountRepository.GetById(id);
			var userAccountModel = _mapper.Map<UserAccountModel>(userAccount);
			return View(userAccountModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, UserAccountModel userAccountModel)
		{
			//try
			{
				UserAccount userAccount = userAccountRepository.GetById(id);
				userAccountRepository.Delete(userAccount);
				return RedirectToAction(nameof(Index));
			}
			//catch
			{
				//return View();
			}
		}
		public ActionResult Edit(int id)
		{
			UserAccount userAccount = userAccountRepository.GetById(id);
			var userAccountModel = _mapper.Map<UserAccountModel>(userAccount);
			return View(userAccountModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, UserAccountModel userAccountModel)
		{
			//UserAccount userAccount = userAccountRepository.GetById(id);
			UserAccount userAccount = _mapper.Map<UserAccount>(userAccountModel);

			userAccountRepository.Update(userAccount);
			return RedirectToAction(nameof(Index));
		}
		public ActionResult Index()
		{
			List<UserAccount> userAccounts = userAccountRepository.GetUserAccounts();
			return View(userAccounts);
		}
	}
}