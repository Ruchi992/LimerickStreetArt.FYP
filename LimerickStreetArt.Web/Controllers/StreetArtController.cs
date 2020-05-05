namespace LimerickStreetArt.Web.Controllers
{
	using LimerickStreetArt.MySQL;
	using LimerickStreetArt.Repository;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;

    public class StreetArtController : Controller
	{
		//TODO: Make default View for controller
		private readonly StreetArtRepository streetArtRepository;
		public StreetArtController(IConfiguration configuration)
		{
			var databaseClass = new DatabaseClass
			{
				ConnectionString = configuration.GetConnectionString("LocalDatabase"),
			};
			streetArtRepository = new StreetArtRepositoryClass(databaseClass);
		}
		// GET: StreetArt
		public ActionResult Index()
		{
			List<StreetArt> streetArtList = streetArtRepository.GetStreetArtList();
			return View(streetArtList);
		}

		// GET: StreetArt/Details/5
		public ActionResult Details(int id)
		{
			StreetArt streetArt = streetArtRepository.GetById(id);
			return View(streetArt);
		}

		// GET: StreetArt/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: StreetArt/Create
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

		// GET: StreetArt/Edit/5
		public ActionResult Edit(int id)
		{
			StreetArt streetArt = streetArtRepository.GetById(id);
			return View(streetArt);
		}

		// POST: StreetArt/Edit/5
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

		// GET: StreetArt/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: StreetArt/Delete/5
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