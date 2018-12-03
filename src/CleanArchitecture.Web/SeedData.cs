using System;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Data;

namespace CleanArchitecture.Web
{
    public static class SeedData
    {
        public static void PopulateTestData(AppDbContext dbContext)
        {
            var toDos = dbContext.ToDoItems;
            foreach (var item in toDos)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();
            dbContext.ToDoItems.Add(new ToDoItem()
            {
                Title = "Test Item 1",
                Description = "Test Description One"
            });
            dbContext.ToDoItems.Add(new ToDoItem()
            {
                Title = "Test Item 2",
                Description = "Test Description Two"
            });

	        var createdGuestbook = new Guestbook();
	        createdGuestbook.Name = "My Guestbook";

	        createdGuestbook.AddEntry(new GuestBookEntry(){ EmailAddress = "thaley@dlr360.com", Message = "hello world", DateTimeCreated = DateTimeOffset.UtcNow.AddHours(-2)});
	        dbContext.Guestbooks.Add(createdGuestbook);

            dbContext.SaveChanges();
        }

    }
}
