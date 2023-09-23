using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleArticleWebAPI.Application.Interface;

namespace SimpleArticleWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticlesController : ControllerBase
	{
		private readonly IArticleService _articleService;
		public ArticlesController(IArticleService articleService)
		{
			_articleService = articleService;
		}

		[HttpGet("GetAllArticles")]
		public async Task<IActionResult> GetAllArticles()
		{
			var getArticlesAndSaveToDB = await _articleService.GetArticles();
			return Ok(getArticlesAndSaveToDB);
		}
	}
}
