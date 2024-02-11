using Microsoft.AspNetCore.Authentication;
using OnlineCasino.Application.Services;
using OnlineCasino.Application.Services.Interfaces;
using OnlineCasino.Persistence.Context;
using OnlineCasino.Persistence.Context.Interfaces;
using OnlineCasino.Persistence.Repositories;
using OnlineCasino.Persistence.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OnlineCasinoDbContext>();

builder.Services.AddScoped<IOnlineCasinoDbContext, OnlineCasinoDbContext>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IGameService, GameService>();

builder.Services.AddTransient<IGameRepository, GameRepository>();

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
