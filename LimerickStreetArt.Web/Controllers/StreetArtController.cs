namespace LimerickStreetArt.Web.Controllers
{
	using AutoMapper;
	using LimerickStreetArt.MySQL;
	using LimerickStreetArt.Repository;
	using LimerickStreetArt.Web.Models;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Configuration;
	using System.Collections.Generic;

	public class StreetArtController : Controller
	{
		private readonly IMapper _mapper;

		private readonly StreetArtRepository streetArtRepository;
		public StreetArtController(IConfiguration configuration, IMapper mapper)
		{
			var databaseClass = new DatabaseClass
			{
				ConnectionString = configuration.GetConnectionString("LocalDatabase"),
			};
			streetArtRepository = new StreetArtRepositoryClass(databaseClass);
			_mapper = mapper;

		}
		// GET: StreetArt/Create
		public ActionResult Create()
		{
			//var item = new StreetArtModel();
			return View();
		}

		// POST: StreetArt/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(StreetArt streetArt)
		{
			try
			{
				streetArtRepository.Create(streetArt);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(streetArt);
			}
		}

		// GET: StreetArt/Details/5
		public ActionResult Details(int id)
		{
			StreetArt streetArt = streetArtRepository.GetById(id);

			var streetArtModel = _mapper.Map<StreetArtModel>(streetArt);

			return View(streetArtModel);
		}
		// POST: StreetArt/Delete/5
		// GET: StreetArt/Delete/5
		public ActionResult Delete(int id)
		{
			var streetArtData = streetArtRepository.GetById(id);
			return View(streetArtData);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, StreetArtModel streetArtModel)
		{
			try
			{
				StreetArt streetArt = streetArtRepository.GetById(id);
				streetArtRepository.Delete(streetArt);
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

			var streetArtModel = _mapper.Map<StreetArtModel>(streetArt);
			return View(streetArtModel);
		}

		// POST: StreetArt/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, StreetArtModel streetArtModel)
		{
			StreetArt streetArt = _mapper.Map<StreetArt>(streetArtModel);
			streetArtRepository.Update(streetArt);
			return RedirectToAction(nameof(Index));
		}
		// GET: StreetArt
		public ActionResult Index()
		{
			List<StreetArt> streetArtList = streetArtRepository.GetStreetArtList();
			return View(streetArtList);
		}




	}
}