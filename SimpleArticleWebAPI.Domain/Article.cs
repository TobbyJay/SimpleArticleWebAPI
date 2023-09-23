using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleArticleWebAPI.Domain
{
	public class Articlee
	{
        public Guid ArticleeId { get; set; }
        public string? Title { get; set; }
        public string? FirstParagraph { get; set; }
        public DateTime DateProcessed { get; set; }
    }
}
