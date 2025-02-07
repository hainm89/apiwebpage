using Ass1.Helpers;
using Ass1.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Ass1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GoodDbContext>(options =>
    options.UseSqlServer("server =(local); database = goodDB;uid=sa;pwd=majonotab1;"));
builder.Services.AddScoped<IGoodRepository, GoodRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
