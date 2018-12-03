using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Core.Services
{
	public class EmailMessageSenderService : IMessageSender
	{
		public void SendGuestbookNotificationEmail(string toAddress, string messageBody)
		{
			var message = new MailMessage();
			message.To.Add(new MailAddress(toAddress));
			message.From = new MailAddress("donotreply@travishaley.com");
			message.Subject = "New Guestbook Entry Addded";
			message.Body = messageBody;
			using (var client = new SmtpClient("localhost", 25))
			{
				client.Send(message);
			}
		}
	}
}
