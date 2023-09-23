using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SimpleArticleWebAPI.Application.DTOs;
using SimpleArticleWebAPI.Application.Interface;
using SimpleArticleWebAPI.Domain;
using SimpleArticleWebAPI.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleArticleWebAPI.Application.Implementations
{
	public class ArticleService : IArticleService
	{
		private readonly AppDbContext _context;
		private readonly IMemoryCache _memoryCache;
		public ArticleService(AppDbContext context, IMemoryCache memoryCache)
		{
			_context = context;
			_memoryCache = memoryCache;
		}

		public async Task<List<Articlee>> GetArticles()
		{
			// check if articles are in cache, if yes retrieve from there
			var articles = await GetArticlesFromSources();
			return articles;
			// else retrieve from DB
		}

		private async Task<List<Articlee>> GetArticlesFromSources()
		{
			if (_memoryCache.TryGetValue("ArticlesKey", out List<Articlee> cachedArticles))
			{
				// Articles found in cache, return them
				//_logger.LogInformation("Articles found in cache. Total count: {Count}", cachedArticles.Count);
				return cachedArticles;
			}
			else
			{
				// No products found in cache, return an empty list
				// Product not found in cache, fetch it from the source
				//_logger.LogInformation("Product not found in cache. Fetching from the data source.");

				// Replace this with code to retrieve the product from your data source
				// For example, you might use a service or database query to get the product

				var articles = await GetArticlesFromDB(); // Replace with actual code
				if (articles != null && articles.Any())
				{
					// Cache the retrieved articles for future use
					var cacheEntryOptions = new MemoryCacheEntryOptions
					{
						AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) // Cache for 10 minutes
					};

					_memoryCache.Set("ArticlesKey", articles, cacheEntryOptions);
				}

				return articles ?? new List<Articlee>(); // Return the retrieved articles or an empty list if none found

			}
		}

		private async Task<List<Articlee>> GetArticlesFromDB()
		{
			var articles = await _context.Articlees.ToListAsync();
			return articles;
		}
	}
}
