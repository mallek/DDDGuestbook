using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Web.Filters;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.Web.Api
{


	[Route("api/[controller]")]
	[ValidateModel]
	public class GuestbookController : Controller
	{

		private readonly IRepository _repository;

		public GuestbookController(IRepository repository)
		{
			_repository = repository;
		}



		// GET: api/Guestbook/1
		[HttpGet("{id:int}")]
		public IActionResult GetById(int id)
		{
			var guestbook = _repository.GetById<Guestbook>(id);
			if (guestbook == null)
			{
				return NotFound(id);
			}

			var entries = _repository.List<GuestBookEntry>();
			guestbook.Entries.Clear();
			guestbook.Entries.AddRange(entries);
			return Ok(guestbook);
		}

		[HttpPost("{id:int}/NewEntry")]
		public IActionResult NewEntry(int id, [FromBody] GuestBookEntry entry)
		{
			var guestbook = _repository.GetById<Guestbook>(id);
			if (guestbook == null)
			{
				return NotFound(id);
			}

			var entries = _repository.List<GuestBookEntry>();
			guestbook.Entries.Clear();
			guestbook.Entries.AddRange(entries);
			guestbook.AddEntry(entry);
			_repository.Update(guestbook);

			return Ok(guestbook);
		}
	}
}
