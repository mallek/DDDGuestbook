using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CleanArchitecture.Core.Events;
using CleanArchitecture.Core.SharedKernel;

namespace CleanArchitecture.Core.Entities
{
	public class Guestbook : BaseEntity
	{
		private List<GuestBookEntry> _entries = new List<GuestBookEntry>();
		public string Name { get; set; }

		public IEnumerable<GuestBookEntry> Entries
		{
			get
			{
				return new ReadOnlyCollection<GuestBookEntry>(_entries);
			}
		} 

		public void AddEntry(GuestBookEntry entry)
		{
			_entries.Add(entry);
			Events.Add(new EntryAddedEvent(this.Id, entry));
		}
	}
}
