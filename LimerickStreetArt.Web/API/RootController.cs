using LimerickStreetArt.Web.Api;
using Microsoft.AspNetCore.Mvc;

namespace LimerickStreetArt.Web.API
{
	[Route("/")]
	[ApiController]
	public class RootController : ControllerBase
	{
		[HttpGet(Name = nameof(Index))]
		public IActionResult Index()
		{
			var response = new
			{
				href = Url.Link(nameof(Index), null),
				streetart = new
				{
					href = Url.Link(nameof(StreetArtController.GetStreetArt), null)
				},
				useraccounts = new
				{
					href = Url.Link(nameof(UserAccountController.GetUserAccounts), null)
				}
			};
			return Ok(response);
		}
	}
}