namespace LimerickStreetArt.Web.Controllers
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;
	using LimerickStreetArt.Web.Models;
	using LimerickStreetArt.Repository;
	using LimerickStreetArt.MySQL;
	using Microsoft.Extensions.Configuration;

	public class HomeController : Controller
	{
		private readonly StreetArtRepository streetArtRepository;

		public HomeController(StreetArtRepository streetArtRepository)
		{

			this.streetArtRepository = streetArtRepository;


		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult ArtMap()
		{
			List<StreetArt> streetArtList = streetArtRepository.GetStreetArtList();
			return View(streetArtList);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
