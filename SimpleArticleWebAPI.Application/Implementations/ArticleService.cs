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
		public ArticleService(AppDbContext context)
		{
			_context = context;
		}

		public async Task<string> GetAriclesFromAPI()
		{
			var client = new HttpClient();
			
			var url = "https://api.wikimedia.org/feed/v1/wikipedia/en/featured/2023/09/22";
			var response = await client.GetAsync(url);

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var data = JsonSerializer.Deserialize<GetFeaturedArticleDTO>(content);

				if (data == null)
				{
					return "no avalable articles for the day";
				}

				SaveArticles(data);

				return "articles";
			}
			else
			{
				// return 500 internal server
			}


			throw new NotImplementedException();
		}

		private void SaveArticles(GetFeaturedArticleDTO getArticle)
		{
			var article = new Articlee
			{
				DateProcessed = DateTime.Now,
				Title = getArticle.tfa.title,
				FirstParagraph = getArticle.tfa.extract
			};

			_context.Add(article);
			_context.SaveChanges();
		}

	}
}
