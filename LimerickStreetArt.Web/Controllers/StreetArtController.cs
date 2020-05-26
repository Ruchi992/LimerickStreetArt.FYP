namespace LimerickStreetArt.Web.Controllers
{
	using AutoMapper;
	using LimerickStreetArt.MySQL;
	using LimerickStreetArt.Repository;
	using LimerickStreetArt.Web.Models;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Configuration;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.IO;
	using static System.Net.Mime.MediaTypeNames;

	public class StreetArtController : Controller
	{
		private readonly IWebHostEnvironment _env;
		private readonly IMapper _mapper;
		private readonly StreetArtRepository streetArtRepository;

		public StreetArtController(IConfiguration configuration, IMapper mapper, IWebHostEnvironment env)
		{
			var databaseClass = new DatabaseClass
			{
				ConnectionString = configuration.GetConnectionString("LocalDatabase"),
			};
			streetArtRepository = new StreetArtRepositoryClass(databaseClass);
			_mapper = mapper;
			_env = env;

		}
		#region Properties
		#endregion
		public string StreetartUploadDirectory { get => Path.Combine(_env.WebRootPath, "images", "streetart"); }
		#region Public Methods
		#endregion
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
			StreetArt streetArt = streetArtRepository.GetById(id);
			_mapper.Map<StreetArtModel, StreetArt>(streetArtModel, streetArt);
			if (streetArtModel.Image != null)
			{
				String fileExtension = Path.GetExtension(streetArtModel.Image.FileName);
				String filename = streetArtModel.Id + fileExtension;
				streetArt.Image = filename;
			}
			else
			{
				streetArt.Image = String.Empty;
			}
			streetArtRepository.Update(streetArt);
			SaveImage(streetArtModel);
			return RedirectToAction(nameof(Index));
		}
		public ActionResult Index()
		{
			List<StreetArt> streetArtList = streetArtRepository.GetStreetArtList();
			return View(streetArtList);
		}
		#region Private Methods
		#endregion
		private void SaveImage(StreetArtModel streetArtModel)
		{
			IFormFile formFile = streetArtModel.Image;
			Console.WriteLine($"Street Art:{streetArtModel.Id}, Content-Type:{formFile.ContentType}");
			if (formFile != null && formFile.Length > 0)
			{
				EnsureStreetartUploadDirectoryExists();

				String fileExtension = Path.GetExtension(formFile.FileName);
				String filename = streetArtModel.Id + fileExtension;
				String filePath = Path.Combine(this.StreetartUploadDirectory, filename);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					formFile.CopyToAsync(fileStream);
				}
			}
		}
		private void EnsureStreetartUploadDirectoryExists()
		{
			if (!Directory.Exists(StreetartUploadDirectory))
			{
				Directory.CreateDirectory(StreetartUploadDirectory);
			}
		}
	}
}