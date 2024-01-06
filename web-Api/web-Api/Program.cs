using web_Api.Extensions;
using web_Api.Middleware;
using Web_Api.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureContexts(builder);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwagger();

builder.Services.ConfigureMapper();

builder.Services.AddAuthorization();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureAuthentication(builder.Configuration);

builder.Services.ConfigureServices();
builder.Services.ConfigureValidators();
builder.Services.ConfigureRepositories();

builder.Services.ConfigureLogger();

var app = builder.Build();

app.MigrateDatabase<LibraryContext>();
app.MigrateDatabase<UserContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();