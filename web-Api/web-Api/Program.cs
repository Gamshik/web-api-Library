using Entites.Entities;
using FluentValidation;
using Interfaces.Repositories;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using web_Api.Extensions;
using web_Api.Middleware;
using Web_Api.BLL.Services;
using Web_Api.BLL.Validation;
using Web_Api.DAL.Context;
using Web_Api.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<LibraryContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), db => db.MigrationsAssembly("web-Api")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.ConfigureSwagger();

builder.Services.ConfigureMapper();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IIssueRepository, IssueRepository>();
builder.Services.AddScoped<IReaderRepository, ReaderRepository>();

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IIssueService, IssueService>();
builder.Services.AddScoped<IReaderService, ReaderService>();

builder.Services.AddScoped<IValidator<Author>, AuthorValidator>();
builder.Services.AddScoped<IValidator<Book>, BookValidator>();
builder.Services.AddScoped<IValidator<Issue>, IssueValidator>();
builder.Services.AddScoped<IValidator<Reader>, ReaderValidator>();

var app = builder.Build();

app.MigrateDatabase<LibraryContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();