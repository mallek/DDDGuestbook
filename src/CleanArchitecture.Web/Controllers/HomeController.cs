using System;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace CleanArchitecture.Web.Controllers
{
    public class HomeController : Controller
    {

	    private readonly IRepository _repository;

		public HomeController(IRepository repository)
	    {
		    _repository = repository;
		}

        public IActionResult Index()
        {
	        if (!_repository.List<Guestbook>().Any())
	        {
		        var createdGuestbook = new Guestbook();
		        createdGuestbook.Name = "My Guestbook";

		        createdGuestbook.Entries.Add(new GuestBookEntry(){ EmailAddress = "thaley@dlr360.com", Message = "hello world", DateTimeCreated = DateTimeOffset.UtcNow.AddHours(-2)});
		        createdGuestbook.Entries.Add(new GuestBookEntry(){ EmailAddress = "travis@haleycomputersolutions.com", Message = "hello world again", DateTimeCreated = DateTimeOffset.UtcNow.AddHours(-3)});
		        createdGuestbook.Entries.Add(new GuestBookEntry(){ EmailAddress = "kcarter@dlr360.com", Message = "hello from Karen"});
		        _repository.Add(createdGuestbook);
	        }

	        var guestbook = _repository.GetById<Guestbook>(1);
	        var guestbookEntries = _repository.List<GuestBookEntry>();
			guestbookEntries.Clear();
			guestbook.Entries.AddRange(guestbookEntries);

	        var vm = new HomePageViewModel();
	        vm.GuestBookName = guestbook.Name;
	        vm.PreviousEntries.AddRange(guestbook.Entries);

	        return View(vm);
        }

		[HttpPost]
	    public IActionResult Index(HomePageViewModel model)
	    {
		    if (ModelState.IsValid)
		    {
			    var guestbookToUpdate = _repository.GetById<Guestbook>(1);
				guestbookToUpdate.AddEntry(model.NewEntry);
			    var guestbookEntries = _repository.List<GuestBookEntry>();


				model.PreviousEntries.Clear();
				model.PreviousEntries.AddRange(guestbookEntries);
				model.PreviousEntries.Add(model.NewEntry);
			    model.GuestBookName = guestbookToUpdate.Name;
		    }

		    return View(model);
	    }

        public IActionResult Error()
        {
            return View();
        }
    }
}
