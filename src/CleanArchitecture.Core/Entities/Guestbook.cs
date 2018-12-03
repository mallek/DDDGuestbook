using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.Events;
using CleanArchitecture.Core.SharedKernel;

namespace CleanArchitecture.Core.Entities
{
	public class Guestbook : BaseEntity
	{
		public string Name { get; set; }
		public List<GuestBookEntry> Entries { get;  } = new List<GuestBookEntry>();

		public void AddEntry(GuestBookEntry entry)
		{
			Entries.Add(entry);
			Events.Add(new EntryAddedEvent(this.Id, entry));
		}
	}
}
