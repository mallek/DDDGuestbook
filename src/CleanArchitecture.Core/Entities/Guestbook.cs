using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.SharedKernel;

namespace CleanArchitecture.Core.Entities
{
	public class Guestbook : BaseEntity
	{
		public string Name { get; set; }
		public List<GuestBookEntry> Entries { get;  } = new List<GuestBookEntry>();
	}
}
