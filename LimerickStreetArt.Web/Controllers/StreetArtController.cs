namespace LimerickStreetArt.Web.Controllers
{
	using AutoMapper;
	using LimerickStreetArt.MySQL;
	using LimerickStreetArt.Repository;
	using LimerickStreetArt.Web.Models;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Configuration;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using static System.Net.Mime.MediaTypeNames;

	public class StreetArtController : Controller
	{
		private readonly IMapper _mapper;
		private readonly StreetArtRepository streetArtRepository;
		private object Directory;

		public StreetArtController(IConfiguration configuration, IMapper mapper)
		{
			var databaseClass = new DatabaseClass
			{
				ConnectionString = configuration.GetConnectionString("LocalDatabase"),
			};
			streetArtRepository = new StreetArtRepositoryClass(databaseClass);
			_mapper = mapper;

		}

		public ActionResult Create()
		{
			//var item = new StreetArtModel();
			return View();
		}
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
		public ActionResult Details(int id)
		{
			StreetArt streetArt = streetArtRepository.GetById(id);

			var streetArtModel = _mapper.Map<StreetArtModel>(streetArt);

			return View(streetArtModel);
		}
		public ActionResult Delete(int id)
		{
			var streetArt = streetArtRepository.GetById(id);
			return View(streetArt);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, StreetArt streetArtModel)
		{
			if (ModelState.IsValid)
			{
				StreetArt streetArt = streetArtRepository.GetById(id);
				try
				{
					streetArtRepository.Delete(streetArt);
					return RedirectToAction(nameof(Index));
				}
				catch (Exception exception)
				{
					ModelState.AddModelError("", $"Failed to Delete {streetArtModel.Id}");
					ModelState.AddModelError("", $"Error: {exception.Message}");
					return View(streetArt);
				}
			}
			else
			{
				ModelState.AddModelError("", $"Nodel is not valid");
				return View(streetArtModel);
			}
		}
		public ActionResult Edit(int id)
		{
			StreetArt streetArt = streetArtRepository.GetById(id);

			var streetArtModel = _mapper.Map<StreetArtModel>(streetArt);
			return View(streetArtModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, StreetArtModel streetArtModel)
		{
			StreetArt streetArt = _mapper.Map<StreetArt>(streetArtModel);
			streetArtRepository.Update(streetArt);
			return RedirectToAction(nameof(Index));
		}
		[HttpPost]
		public IActionResult ImageUpload(IFormFile file)
		{
			if (file != null && file.Length > 0)
			{
				var imagePath = @"\Upload\Image\";
				var uploadPath = env.WebRootPath + imagePath;

				if (Directory.Exists(uploadPath))
				{
					Directory.CreateDirectory(uploadPath);
				}
			}
		}
		public ActionResult Index()
		{
			List<StreetArt> streetArtList = streetArtRepository.GetStreetArtList();
			return View(streetArtList);
		}
	}
}