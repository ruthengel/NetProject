using EasyDiet.Core.Models;
using EasyDiet.Core.Interfaces;
using EasyDiet.Data;
using EasyDiet.Services;
using EasyDiet.Data.Repositories;
using EasyDiet.Core.Repositories;
using EasyDiet.Core.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICoachServices, CoachServices>();
builder.Services.AddScoped<ICoachRepository, CoachRepository>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IDietServices, DietServices>();
builder.Services.AddScoped<IDietRepository, DietRepository>();
builder.Services.AddSingleton<IDataContext, DataContext>();
builder.Services.AddDbContext<DataContext>();
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
