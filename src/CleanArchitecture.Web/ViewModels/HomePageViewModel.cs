using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Web.ViewModels
{
	public class HomePageViewModel
	{
		public string GuestBookName { get; set; }
		public List<GuestBookEntry> PreviousEntries { get; } = new List<GuestBookEntry>();
		public GuestBookEntry NewEntry { get; set; }

	}
}
