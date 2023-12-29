using AutoMapper;
using Microsoft.OpenApi.Models;
using Web_Api.BLL.Profiles;

namespace web_Api.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfiles(new List<Profile>
            {
                new AuthorProfile(),
                new BookProfile(),
                new IssueProfile(),
                new ReaderProfile()
            }));

            services.AddScoped<IMapper>(m => new Mapper(config));
        }
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Innovate work Api", Version = "v1" });
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        new string[]{}
                    }
                });
            });
        }
    }
}
