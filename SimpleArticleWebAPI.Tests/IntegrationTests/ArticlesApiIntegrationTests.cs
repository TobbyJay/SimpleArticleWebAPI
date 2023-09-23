using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleArticleWebAPI.Tests.IntegrationTests
{
	public class ArticlesApiIntegrationTests
	{
		private readonly string _baseUrl = "https://api.wikimedia.org";

		[Fact]
		public async Task FetchTodaysFeaturedArticleFromWikipedia_Should_ReturnSuccessStatusCode()
		{
			// Arrange
			var client = new RestClient(_baseUrl);
			var request = new RestRequest("/feed/v1/wikipedia/en/featured/2023/09/23", Method.Get);

			try
			{
				// Act
				var response = await client.ExecuteAsync(request);

				// Assert
				Assert.Equal(HttpStatusCode.OK, response.StatusCode);
			}
			catch (Exception ex)
			{
				// Handle unexpected exceptions
				Assert.True(false, $"Integration test failed with exception: {ex.Message}");
			}
		}
	}
}
