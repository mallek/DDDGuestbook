using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Web.ApiModels
{
	public class GuestbookDto
	{
		public int Id { get; set; }
		public List<GuestbookEntryDto> Entries { get; set; }

		public static GuestbookDto FromGuestbook(Guestbook item)
		{
			var dto = new GuestbookDto();
			dto.Id = item.Id;
			foreach (var entry in item.Entries)
			{
				dto.Entries.Add(new GuestbookEntryDto()
				{
					Id = entry.Id,
					EmailAddress = entry.EmailAddress,
					Message = entry.Message,
					DateTimeCreated = entry.DateTimeCreated
				});
			}
			return dto;
		}
	}
}
