using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Core.Specifications
{
	public class GuestbookNotificationPolicy : ISpecification<GuestBookEntry>
	{
		public GuestbookNotificationPolicy(int entryAddedId = 0)
		{
			Criteria = x => x.DateTimeCreated > DateTimeOffset.UtcNow.AddDays(-1) && x.Id != entryAddedId;
		}

		public Expression<Func<GuestBookEntry, bool>> Criteria { get; }
	}
}
