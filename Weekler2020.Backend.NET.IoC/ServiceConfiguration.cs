using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weekler2020.Backend.NET.Infrastructure.Database;

namespace Weekler2020.Backend.NET.IoC
{
	public static class ServiceConfiguration
	{
		public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
		{
			ConfigureApplicationServices(services);
			ConfigureRepositories(services, configuration);
		}

		private static void ConfigureApplicationServices(IServiceCollection services)
		{
			var mappingConfig = new MapperConfiguration(mc =>
			{
				//mc.AddProfile();
			});

			//authorization....

			//services.AddTransient<IHairDresserService, HairDresserService>();

			services.AddSingleton(mappingConfig.CreateMapper());
		}

		private static void ConfigureRepositories(IServiceCollection services, IConfiguration configuration)
		{
			var dbConfig = configuration.GetSection(nameof(DbConfig)).Get<DbConfig>();

			//services.AddTransient<IHairDresserRepository, HairDresserRepository>();
		}
	}
}