using DigiMoviezClone.Infrastructure.Persistence;
using DigiMoviezClone.Domain.Entities;
using DigiMoviezClone.Infrastructure.Repositories;
using DigiMoviezClone.Application.Configuration;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DigiMoviezClone.API.Configuration;
using DigiMoviezClone.API.MappingProfiles;
using DigiMoviezClone.Application.MappingProfiles;
using DigiMoviezClone.Application.Services;
using DigiMoviezClone.Infrastructure;
using DigiMoviezClone.Domain.Repositories;
using DigiMoviezClone.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DigiMoviezClone.API.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configure Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutoMapperModule());
    containerBuilder.RegisterModule(new DependencyInjectionModule());
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register application services & repositories
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IMovieRepository, EfMovieRepository>();
builder.Services.AddScoped<IGenreRepository, EfGenreRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
// JWT settings
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings"));

builder.Services.AddScoped<IUserService, UserService>();

// Authentication & Authorization
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidateAudience = true,
        ValidAudience = jwtSettings.Audience,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();

// Add AutoMapper profiles
builder.Services.AddAutoMapper(typeof(CommentProfile));
builder.Services.AddAutoMapper(typeof(UserMappingProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();

// ⚡ باید قبل از UseAuthorization بیاد
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
