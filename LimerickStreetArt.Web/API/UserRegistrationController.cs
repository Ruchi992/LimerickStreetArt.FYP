using LimerickStreetArt.Repository;
using LimerickStreetArt.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LimerickStreetArt.Web.API
{
	[Authorize]
	[Route("api/UserAccount")]
	[Route("api/[controller]")]
	//[ApiController]

	public class UserRegistrationController : ControllerBase
	{
		private UserAccountRepository UserAccountRepository { get; }

		public UserRegistrationController(UserAccountRepository userAccountRepository)
		{
			UserAccountRepository = userAccountRepository;
		}
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<String> Get()
		{
			return Ok("You have reached User Registration.");
		}

		[HttpPatch]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<bool> Register([FromBody]RegistrationModel registrationModel)
		{
			if (ModelState.IsValid)
			{
				bool passwordsDoNotMatch = registrationModel.Password != registrationModel.ReconformPassword;
				bool usernameIsTaken = false;
				bool emailIsInUse = false;

				if (usernameIsTaken)
				{
					ModelState.AddModelError("", "Usernme is already In use.");
				}
				if (emailIsInUse)
				{
					ModelState.AddModelError("", "e-mail is already In use.");
				}
				if (passwordsDoNotMatch)
				{
					ModelState.AddModelError("", "Passwords don't match.");
				}

				if (!usernameIsTaken && !emailIsInUse && !passwordsDoNotMatch)
				{
					var userAccount = new UserAccount
					{
						AccessLevel = 2,
						Active = true,
						DateOfBirth = registrationModel.DateOfBirth,
						Email = registrationModel.Email,
						Password = registrationModel.Password,
						Username = registrationModel.Username,
					};
					UserAccountRepository.Create(userAccount);
					return true;
				}
				else
				{
					return false;
				}
			}
			return false;
			//			return CreatedAtAction(nameof(Get), new { item.Id }, item);
		}
	}
}

