using System;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
	        var guestbook = new Guestbook();
	        guestbook.Name = "My Guestbook";

			guestbook.Entries.Add(new GuestBookEntry(){ EmailAddress = "thaley@dlr360.com", Message = "hello world", DateTimeCreated = DateTimeOffset.UtcNow.AddHours(-2)});
			guestbook.Entries.Add(new GuestBookEntry(){ EmailAddress = "travis@haleycomputersolutions.com", Message = "hello world again", DateTimeCreated = DateTimeOffset.UtcNow.AddHours(-3)});
	        guestbook.Entries.Add(new GuestBookEntry(){ EmailAddress = "kcarter@dlr360.com", Message = "hello from Karen"});

	        var vm = new HomePageViewModel();
	        vm.GuestBookName = guestbook.Name;
	        vm.PreviousEntries.AddRange(guestbook.Entries);

	        return View(vm);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
