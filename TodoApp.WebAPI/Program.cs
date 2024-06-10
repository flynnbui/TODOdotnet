using System.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TodoApp.Core.Entities;
using TodoApp.Infrastructure.Data;
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


// Add services to the container.

var app = builder.Build();

app.Run();

