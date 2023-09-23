using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleArticleWebAPI.Application.DTOs;
using SimpleArticleWebAPI.Domain;
using SimpleArticleWebAPI.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleArticleWebAPI.BackgroundJob
{
	public class ArticlesBackgroundService : BackgroundService
	{
		private readonly IServiceProvider _serviceProvider;
		public ArticlesBackgroundService(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}
		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				// time of day set to (12:05am)
				var scheduledTimeToRunTask = DateTime.Today.Add(new TimeSpan(0, 5, 0));

				string formatTime = scheduledTimeToRunTask.ToString("yyyy/MM/dd");

				// calculate delay until next scheduled time
				var delay = scheduledTimeToRunTask > DateTime.Now
							? scheduledTimeToRunTask - DateTime.Now
							: scheduledTimeToRunTask.AddDays(1) - DateTime.Now;

				using (var scope = _serviceProvider.CreateAsyncScope())
				{
					var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
					var cache = scope.ServiceProvider.GetRequiredService<IMemoryCache>();
					var _configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

					await FetchTodaysFeaturedArticleFromWikipedia(cache, dbContext, _configuration, formatTime);
				}
				
				//await Task.Delay(delay, stoppingToken);
				await Task.Delay(TimeSpan.FromMinutes(2), stoppingToken);
			}
			throw new NotImplementedException();
		}

		private async Task FetchTodaysFeaturedArticleFromWikipedia(IMemoryCache cache, AppDbContext context,IConfiguration configuration, string date)
		{
			var client = new HttpClient();

			var baseUrl = configuration["FeaturedArticleUrl"];
			var url = $"{baseUrl}{date}";

			var response = await client.GetAsync(url);

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var data = JsonSerializer.Deserialize<GetFeaturedArticleDTO>(content);

				if (data == null)
				{
					// log here "no avalable articles for the day";
				}

				SaveArticle(data, context, cache);
				 // log here "Features article for the day saved";
			}
			else
			{
				// return 500 internal server
			}
		}
		private void SaveArticle(GetFeaturedArticleDTO getArticle, AppDbContext _context, IMemoryCache cache)
		{
			var modifiedParagraph = FindAndModifyConcepts(getArticle.tfa.extract);

			var article = new Articlee
			{
				DateProcessed = DateTime.Now,
				Title = getArticle.tfa.title,
				FirstParagraph = getArticle.tfa.extract,
				ModifiedParagraph = modifiedParagraph
			};

			// save to localDb
			_context.Add(article);
			_context.SaveChanges();

			// save to cache
			SaveToCache(article,cache);
		}

		public static string FindAndModifyConcepts(string text)
		{
			// Split the text into words using various delimiters (space, comma, period, and so on)

			string[] words = text.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

			// Define a regular expression pattern to match capitalized words ( my assumption is that wikipedia sets concepts as starting with an UppserCase )
			string pattern = @"(\b[A-Z][a-z]*\b)";

			StringBuilder modifiedText = new StringBuilder(text);

			foreach (string word in words)
			{
				Match match = Regex.Match(word, pattern);

				if (match.Success)
				{
					// Extracting the matched concept
					string concept = match.Groups[0].Value;
					// Extract the matched concept
					string modifiedConcept = "frigging " + concept;
					modifiedText.Replace(concept, modifiedConcept);
				}
			}
			// After modifying the text, remove any consecutive "frigging" occurrences ( my algorithm returns double friggings.
			return RemoveDoubleFriggings(modifiedText.ToString());
		}
		public static string RemoveDoubleFriggings(string paragraph)
		{
			// Define a regular expression pattern to match consecutive "frigging" words
			string pattern = @"\bfrigging frigging\b";

			string modifiedParagraph = Regex.Replace(paragraph, pattern, "frigging");

			return modifiedParagraph;
		}

		private void SaveToCache(Articlee article, IMemoryCache cache)
		{
			// Retrieve the existing list of articles from the cache, or create a new list if it doesn't exist
			var cachedArticles = cache.TryGetValue("ArticlesKey", out List<Articlee> existingArticles)
				? existingArticles
				: new List<Articlee>();

			// Add the new product to the list
			cachedArticles.Add(article);

			var cacheEntryOptions = new MemoryCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = null
			};

			// Save the updated list of products back to the cache
			cache.Set("ArticlesKey", article, cacheEntryOptions);

			//_logger.LogInformation("Product saved to cache.");
		}
	}
}
