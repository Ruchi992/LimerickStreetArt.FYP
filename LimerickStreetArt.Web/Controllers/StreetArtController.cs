﻿namespace LimerickStreetArt.Web.Controllers
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
	using System.Threading.Tasks;
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
		public ActionResult Create(StreetArt StreetArtModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					streetArtRepository.Create(StreetArtModel);
					var streetArModel = _mapper.Map<StreetArtModel>(StreetArtModel);
					return RedirectToAction(nameof(Index));
				}
				catch
				{
					return View(StreetArtModel);
				}
			}

			else
			{
				ModelState.AddModelError("", $"Model is not valid");
				return View(StreetArtModel);
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

			var streetArtEditModel = _mapper.Map<StreetArtEditModel>(streetArt);
			return View(streetArtEditModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, StreetArtEditModel streetArtEditModel)
		{
			if (ModelState.IsValid)
			{
				StreetArt streetArt = streetArtRepository.GetById(id);
				try
				{
					_mapper.Map<StreetArtEditModel, StreetArt>(streetArtEditModel, streetArt);
					streetArt.Image = SaveImageAsync(streetArtEditModel).Result;
					streetArtRepository.Update(streetArt);
					return RedirectToAction(nameof(Index));
				}
				catch (Exception exception)
				{
					ModelState.AddModelError("", $"Failed to Edit {streetArtEditModel.Id}");
					ModelState.AddModelError("", $"Error: {exception.Message}");
					return View(streetArt);
				}
			}
			else
			{
				ModelState.AddModelError("", $"Model is not valid");
				return View(streetArtEditModel);
			}


		}
		public ActionResult Index()
		{
			List<StreetArt> streetArtList = streetArtRepository.GetStreetArtList();
			return View(streetArtList);
		}
		#region Private Methods
		#endregion
		private async Task<string> SaveImageAsync(StreetArtEditModel streetArtModel)
		{
			IFormFile formFile = streetArtModel.Image;
			Console.WriteLine($"Street Art:{streetArtModel.Id}, Content-Type:{formFile.ContentType}");
			if (formFile != null && ValidFileSize(formFile) && ValidFileImageFormat(formFile))
			{
				EnsureStreetartUploadDirectoryExists();

				String fileExtension = Path.GetExtension(formFile.FileName);
				String filename = streetArtModel.Id + fileExtension;
				String filePath = Path.Combine(this.StreetartUploadDirectory, filename);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					await formFile.CopyToAsync(fileStream);
					return filename;
				}
			}
			return string.Empty;
		}

		private static bool ValidFileSize(IFormFile formFile)
		{
			return formFile.Length > 0 && formFile.Length <= maxFileSize;
		}
		private static bool ValidFileImageFormat(IFormFile formFile)
		{
			var fileExtension = Path.GetExtension(formFile.FileName);
			return fileExtension.ToLower() == jpeg;
		}
		private readonly static string jpeg = ".jpg";
		private readonly static int maxFileSize = 2000000;

		private void EnsureStreetartUploadDirectoryExists()
		{
			if (!Directory.Exists(StreetartUploadDirectory))
			{
				Directory.CreateDirectory(StreetartUploadDirectory);
			}
		}
	}
}