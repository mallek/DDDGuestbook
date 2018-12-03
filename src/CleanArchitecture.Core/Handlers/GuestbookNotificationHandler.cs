using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Events;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Specifications;

namespace CleanArchitecture.Core.Handlers
{
	public class GuestbookNotificationHandler : IHandle<EntryAddedEvent>
	{
		private readonly IRepository _repo;
		private readonly IMessageSender _messageSender;

		public GuestbookNotificationHandler(IRepository repo, IMessageSender messageSender)
		{
			_repo = repo;
			_messageSender = messageSender;
		}

		public void Handle(EntryAddedEvent domainEvent)
		{
			var gbnotificationpolicy = new GuestbookNotificationPolicy(domainEvent.Entry.Id);

			var emailsToNotify = _repo.List(gbnotificationpolicy).Select(e => e.EmailAddress);

			foreach (var email in emailsToNotify)
			{
				string messageBody = $"{domainEvent.Entry.EmailAddress} left a new message {domainEvent.Entry.Message}";
				_messageSender.SendGuestbookNotificationEmail(email, messageBody);
			}

		}
	}
}
