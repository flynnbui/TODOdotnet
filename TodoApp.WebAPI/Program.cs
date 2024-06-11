using System.Configuration;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TodoApp.Core.Entities;
using TodoApp.Core.Interfaces;
using TodoApp.Core.Services;
using TodoApp.Infrastructure.Data;
using TodoApp.Infrastructure.Repositories;

using DbContext = System.Data.Entity.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Get the connection string from appsettings.json
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
// Register the DbContext with the PostgreSQL provider
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connString));

// For Entity Framework
builder.Services.AddIdentity<TodoUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var jwtKey = builder.Configuration.GetSection("JWTSettings:Key").Value;
var key = Encoding.ASCII.GetBytes(jwtKey);

builder.Services.AddAuthentication(config =>
    {
        config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(config =>
    {
        config.RequireHttpsMetadata = false;
        config.SaveToken = true;
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = false,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// Register Dependencies
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ITodoService, TodoService>();

// Add Controller service
builder.Services.AddControllers();

// Add services to the container.

var app = builder.Build();

app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();


app.Run();

