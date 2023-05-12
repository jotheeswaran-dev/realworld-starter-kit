using System.Xml.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealWorld_Api.DBContext;
using RealWorld_Api.Repositories;
using RealWorld_Api.Services;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore.Sqlite;
using RealWorld_Api.Helpers;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//add sqllite connection
builder.Services.AddDbContext<RealWorldDbContext>(options =>
    options.UseSqlite("Data Source=realworld.db"));

//add swagger UI
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "RealWorld-Api", Version = "v1" });
});

//add scoped services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//add IhttpContextAccessor
builder.Services.AddHttpContextAccessor();

//add password hasher
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
