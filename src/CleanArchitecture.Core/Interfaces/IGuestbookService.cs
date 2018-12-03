using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Interfaces
{
	public interface IGuestbookService
	{
		void RecordEntry(Guestbook guestbook, GuestBookEntry newEntry);
	}
}
