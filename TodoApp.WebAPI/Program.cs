using System.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TodoApp.Core.Entities;
using TodoApp.Core.Interfaces;
using TodoApp.Core.Services;
using TodoApp.Infrastructure.Data;
using TodoApp.Infrastructure.Repositories;
using TodoApp.WebAPI.Controllers;

using DbContext = System.Data.Entity.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string from appsettings.json
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
// Register the DbContext with the PostgreSQL provider
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connString));

// For Entity Framework
builder.Services.AddIdentity<TodoUser
        , IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Register Dependencies
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ITodoService, TodoService>();

// Add Controller service
builder.Services.AddControllers();
Console.WriteLine("Hello?");

// Add services to the container.

var app = builder.Build();

app.UseRouting();
app.MapControllers();


app.Run();

