using AutoMapper;
using Contracts.Managers;
using Contracts.Providers;
using Contracts.Repositories;
using Contracts.Services;
using Entites.Entities;
using Entities.Entities;
using FluentValidation;
using LoggerService.Managers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using System.Text;
using web_Api.Profiles;
using Web_Api.BLL.Providers;
using Web_Api.BLL.Services;
using Web_Api.BLL.Validation;
using Web_Api.DAL.Context;
using Web_Api.DAL.Repositories;
using Web_Api.DAL.Repositories.Manager;

namespace web_Api.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureContexts(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<LibraryContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), db => db.MigrationsAssembly("web-Api")));
            services.AddDbContext<UserContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("UserConnection"), db => db.MigrationsAssembly("web-Api")));
        }
        public static void ConfigureMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfiles(new List<Profile>
            {
                new AuthorProfile(),
                new BookProfile(),
                new IssueProfile(),
                new ReaderProfile(),
                new UserProfile(),
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
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<UserContext>();

            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequireUppercase = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireDigit = true;
                opt.Password.RequireNonAlphanumeric = false;

                opt.User.RequireUniqueEmail = true;

                opt.SignIn.RequireConfirmedPhoneNumber = false;
                opt.SignIn.RequireConfirmedEmail = false;
            });
        }
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSetting = configuration.GetSection("JwtSetting");

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSetting.GetSection("Issuer").Value,
                ValidAudience = jwtSetting.GetSection("Audience").Value,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.GetSection("SecurityKey").Value))
            });
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IIssueService, IssueService>();
            services.AddScoped<IReaderService, ReaderService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtProvider, JwtProvider>();
        }
        public static void ConfigureValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<Author>, AuthorValidator>();
            services.AddScoped<IValidator<Book>, BookValidator>();
            services.AddScoped<IValidator<Issue>, IssueValidator>();
            services.AddScoped<IValidator<Reader>, ReaderValidator>();
        }
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
        public static void ConfigureLogger(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();

            LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
        }
    }
}
