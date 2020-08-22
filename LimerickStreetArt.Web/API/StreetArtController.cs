namespace LimerickStreetArt.Web.Api
{
	using LimerickStreetArt;
	using LimerickStreetArt.Repository;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	[Route("api/[controller]")]
	[ApiController]
	public class StreetArtController : ControllerBase
	{
		private StreetArtRepository StreetArtRepository { get; }

		public StreetArtController(StreetArtRepository streetArtRepository)
		{
			StreetArtRepository = streetArtRepository;
		}
		[HttpGet(Name = nameof(GetStreetArt))]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<IEnumerable<StreetArt>> GetStreetArt()
		{
			return Ok(StreetArtRepository.GetStreetArtList());
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<StreetArt> GetAction(int id)
		{
			StreetArt streetArt = StreetArtRepository.GetById(id);

			if (streetArt == null)
				return NotFound();

			return Ok(streetArt);
		}

		[HttpGet("[action]/{searchText}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<IEnumerable<StreetArt>> Search(String searchText)
		{
			var streetArtList = StreetArtRepository.GetStreetArtList();

			var results = streetArtList.Where(streetArt => streetArt.Title.Contains(searchText));

			return Ok(results);
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<StreetArt> Create([FromBody]StreetArt item)
		{
			StreetArtRepository.Create(item);
			return CreatedAtAction(nameof(GetStreetArt), new { item.Id }, item);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult Put(Int32 id, [FromBody] StreetArt streetArt)
		{
			if (id != streetArt.Id)
			{
				return BadRequest();
			}
			try
			{
				StreetArtRepository.Update(streetArt);
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
		public ActionResult<StreetArt> Delete(int id)
		{
			StreetArt streetArt = StreetArtRepository.GetById(id);
			if (streetArt == null)
				return NotFound();
			StreetArtRepository.Delete(streetArt);
			return Ok(streetArt);
		}
	}
}
