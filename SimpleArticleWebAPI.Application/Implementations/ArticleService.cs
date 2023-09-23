using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
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
		private readonly ILogger<ArticleService> _logger;
		public ArticleService(AppDbContext context, IMemoryCache memoryCache, ILogger<ArticleService> logger)
		{
			_context = context;
			_memoryCache = memoryCache;
			_logger = logger;
		}

		public async Task<List<Articlee>> GetArticles()
		{
			var articles = await GetArticlesFromSources();
			return articles;
		}

		private async Task<List<Articlee>> GetArticlesFromSources()
		{
			if (_memoryCache.TryGetValue("ArticlesKey", out List<Articlee> cachedArticles))
			{
				// Articles found in cache, return them
				_logger.LogInformation("Articles found in cache. Total count: {Count}", cachedArticles.Count);
				return cachedArticles;
			}
			else
			{

				_logger.LogInformation("Articles not found in cache. Fetching from the database.");

				var articles = await GetArticlesFromDB(); 
				if (articles != null && articles.Any())
				{
					// Cache the retrieved articles for future use
					var cacheEntryOptions = new MemoryCacheEntryOptions
					{
						AbsoluteExpirationRelativeToNow = null 
					};

					_memoryCache.Set("ArticlesKey", articles, cacheEntryOptions);
				}

				return articles ?? new List<Articlee>(); 
			}
		}

		private async Task<List<Articlee>> GetArticlesFromDB()
		{
			var articles = await _context.Articlees.ToListAsync();
			return articles;
		}
	}
}
