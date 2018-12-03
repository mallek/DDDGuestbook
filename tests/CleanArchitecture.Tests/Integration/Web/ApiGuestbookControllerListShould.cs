using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Web;
using CleanArchitecture.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Xunit;

namespace CleanArchitecture.Tests.Integration.Web
{
	public class ApiGuestbookControllerListShould : IClassFixture<CustomWebApplicationFactory<Startup>>
	{
		private readonly HttpClient _client;

		public ApiGuestbookControllerListShould(CustomWebApplicationFactory<Startup> factory)
		{
			_client = factory.CreateClient();
		}

		[Fact]
		public async Task ReturnsOneGuestbook()
		{
			var response = await _client.GetAsync("/api/guestbook/1");
			response.EnsureSuccessStatusCode();
			var stringResponse = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<GuestbookDto>(stringResponse);

			Assert.Equal(1, result.Id);
			Assert.True(result.Entries.Any());

		}

		[Fact]
		public async Task Returns404ForBadGuestbookId()
		{
			var response = await _client.GetAsync("/api/guestbook/9");
			Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

		}
	}
}
