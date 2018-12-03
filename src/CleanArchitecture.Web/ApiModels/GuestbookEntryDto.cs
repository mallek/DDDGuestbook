using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels
{
	public class GuestbookEntryDto
	{
		public int Id { get; set; }
		public string EmailAddress { get; set; }
		public string Message { get; set; }
		public DateTimeOffset DateTimeCreated { get; set; }
	}
}
