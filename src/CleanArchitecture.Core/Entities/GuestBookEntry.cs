using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.SharedKernel;

namespace CleanArchitecture.Core.Entities
{
	public class GuestBookEntry : BaseEntity
	{
		public string EmailAddress { get; set; }
		public string Message { get; set; }
		public DateTimeOffset DateTimeCreated { get; set; } = DateTime.UtcNow;
	}
}
