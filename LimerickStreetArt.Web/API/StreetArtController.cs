namespace LimerickStreetArt.Web.Api
{
	using LimerickStreetArt;
	using LimerickStreetArt.Repository;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;
	using System;
	using System.Collections.Generic;
	[Route("api/streetart")]
	[ApiController]
	public class StreetArtController : ControllerBase
	{
		private StreetArtRepository StreetArtRepository { get; }

		public StreetArtController(StreetArtRepository streetArtRepository)
		{
			StreetArtRepository = streetArtRepository;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<IEnumerable<StreetArt>> Get()
		{
			return Ok(StreetArtRepository.GetStreetArtList());
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<StreetArt> Get(int id)
		{
			StreetArt streetArt = StreetArtRepository.GetById(id);

			if (streetArt == null)
				return NotFound();

			return Ok(streetArt);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<StreetArt> Create([FromBody]StreetArt item)
		{
			StreetArtRepository.Create(item);
			return CreatedAtAction(nameof(Get), new { item.Id }, item);
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
