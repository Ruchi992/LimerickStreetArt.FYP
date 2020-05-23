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
		//TODO: RD Mehtods in alphabet order
		private readonly IMapper _mapper;

		//TODO: Make default View for controller
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
		// GET: StreetArt
		public ActionResult Index()
		{
			List<StreetArt> streetArtList = streetArtRepository.GetStreetArtList();
			return View(streetArtList);
		}

		// GET: StreetArt/Create
		public ActionResult Create()
		{

			var item = new StreetArtModel();
			return View(item);
		}

		// POST: StreetArt/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(StreetArtModel streetArtModel)
		{
			//TODO Create here
			try
			{
				var streetArt = new StreetArt { Street = streetArtModel.Street };

				// TODO: streetArt.UserAccountId = loggedInUser;
				//

				streetArtRepository.Create(streetArt);
				return RedirectToAction(nameof(Details), new { streetArt.Id });
			}
			catch
			{
				return View(streetArtModel);
			}
		}
		// GET: StreetArt/Details/5
		public ActionResult Details(int id)
		{
			StreetArt streetArt = streetArtRepository.GetById(id);

			var streetArtModel = _mapper.Map<StreetArtModel>(streetArt);

			return View(streetArtModel);
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

		// GET: StreetArt/Delete/5
		public ActionResult Delete(int id)
		{
			var streetArtData = streetArtRepository.GetById(id);
			return View(streetArtData);
		}

		// POST: StreetArt/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, StreetArt streetArtData)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(streetArtData);
			}
		}
	}
}