using SimpleArticleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleArticleWebAPI.Application.Interface
{
	public interface IArticleService
	{
		//public void SaveArticles(Article article);
	    Task<List<Articlee>> GetArticles();
    }
}
