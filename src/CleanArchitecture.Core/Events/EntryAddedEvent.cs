using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.SharedKernel;

namespace CleanArchitecture.Core.Events
{
	public class EntryAddedEvent : BaseDomainEvent
	{
		public int GuestbookId;
		public GuestBookEntry  Entry;

		public EntryAddedEvent(int guestbookId, GuestBookEntry entry)
		{
			GuestbookId = guestbookId;
			Entry = entry;
		}

	}
}
