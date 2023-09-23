using Microsoft.EntityFrameworkCore;
using SimpleArticleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleArticleWebAPI.Persistence
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        public DbSet<Articlee> Articlees { get; set; }
    }
}
