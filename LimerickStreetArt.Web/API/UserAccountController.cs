using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using LimerickStreetArt.Repository;
using Microsoft.AspNetCore.Mvc;
namespace LimerickStreetArt.Web.API
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserAccountController : ControllerBase
	{
		private UserAccountRepository UserAccountRepository { get; }

		public UserAccountController(UserAccountRepository userAccountRepository)
		{
			UserAccountRepository = userAccountRepository;
		}
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<IEnumerable<UserAccount>> Get(int id)
		{
			return Ok(UserAccountRepository.GetById(id));
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<UserAccount> GetAction(int id)
		{
			UserAccount userAccount = UserAccountRepository.GetById(id);

			if (userAccount == null)
				return NotFound();

			return Ok(userAccount);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<UserAccount> Create([FromBody]UserAccount item)
		{
			UserAccountRepository.Create(item);
			return CreatedAtAction(nameof(Get), new { item.Id }, item);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult Put(Int32 id, [FromBody] UserAccount userAccount)
		{
			if (id != userAccount.Id)
			{
				return BadRequest();
			}
			try
			{
				UserAccountRepository.Update(userAccount);
			}
			catch (Exception)
			{
				return BadRequest("Error while editing item");
			}
			return NoContent();
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<UserAccount> Delete(int id)
		{
			UserAccount userAccount = UserAccountRepository.GetById(id);
			if (userAccount == null)
				return NotFound();
			UserAccountRepository.Delete(userAccount);
			return Ok(userAccount);
		}
	}
}

