using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleArticleWebAPI.Application.Implementations;
using SimpleArticleWebAPI.Application.Interface;
using SimpleArticleWebAPI.BackgroundJob;
using SimpleArticleWebAPI.Persistence;

namespace SimpleArticleWebAPI.ServiceExtensions
{
	public static class ServiceExtension
	{
		public static void RegisterSQLDbContext(this IServiceCollection service, IConfiguration configuration)
		{
			service.AddDbContextPool<AppDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("ArticleConnection")));
		}
		
		public static void RegisterServices(this IServiceCollection service)
		{
			service.AddScoped<IArticleService, ArticleService>();
		}
		
		public static IServiceCollection RegisterBackgroundService(this IServiceCollection service)
		{
			service.AddHostedService<ArticlesBackgroundService>();
			return service;
		}
	}
}
