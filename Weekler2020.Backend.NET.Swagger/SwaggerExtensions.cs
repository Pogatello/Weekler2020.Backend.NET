using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace KingICT.Academy2020.Backend.NET.Infra.Swagger
{
	public static class SwaggerExtensions
	{
		public static void AddSwagger(this IServiceCollection services, string apiTitle, string version = "v1", bool enableAuthentication = false)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc(version,
					new OpenApiInfo
					{
						Title = apiTitle,
						Version = version
					});

				if (enableAuthentication)
				{
					c.AddSecurityDefinition("Bearer",
						new OpenApiSecurityScheme
						{
							In = ParameterLocation.Header,
							Description = "Please insert JWT with Bearer into field",
							Name = "Authorization",
							Type = SecuritySchemeType.ApiKey
						});

					c.AddSecurityRequirement(new OpenApiSecurityRequirement
					{
						{
							new OpenApiSecurityScheme
							{
								Reference = new OpenApiReference
								{
									Type = ReferenceType.SecurityScheme,
									Id = "Bearer"
								}
							},
							new string[] { }
						}
					});
				}

				c.CustomSchemaIds(x => x.FullName);
			});
		}
	}
}