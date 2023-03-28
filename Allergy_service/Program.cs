
using EntityApi;
using Models;
using EntityApi.Entities;
using Microsoft.EntityFrameworkCore;
using Allergy_Business_Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var config = builder.Configuration.GetConnectionString("connectionString");
builder.Services.AddDbContext<AllergyDbContext>(options => options.UseSqlServer(config));
builder.Services.AddScoped<IRepo<EntityApi.Entities.Allergy>, EntityApi.Repo>();
builder.Services.AddScoped<ILogic, Logic>();


builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
