using DigiMoviezClone.Infrastructure.Persistence;
using DigiMoviezClone.Domain.Entities;
using DigiMoviezClone.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DigiMoviezClone.API.Configuration;
using DigiMoviezClone.API.DTOs;
using DigiMoviezClone.Application.MappingProfiles;
using DigiMoviezClone.Application.Services;
using DigiMoviezClone.Infrastructure;
using DigiMoviezClone.Domain.Repositories;
using DigiMoviezClone.Domain.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutoMapperModule()); 
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IMovieRepository, EfMovieRepository>();
builder.Services.AddScoped<IGenreRepository, EfGenreRepository>();
builder.Services.AddScoped<ICommentService,CommentService>();
builder.Services.AddAutoMapper(typeof(CommentProfile));
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutoMapperModule());
    containerBuilder.RegisterModule(new DependencyInjectionModule());
});
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

app.UseAuthorization();

app.MapControllers();

app.Run();