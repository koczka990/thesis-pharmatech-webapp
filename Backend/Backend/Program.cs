using Backend.DLL.Context;
using Backend.DLL.Repositories;
using Backend.DLL.Repositories.Interfaces;
using Backend.Services;
using Backend.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>();

builder.Services.AddScoped<ICountingDataService, CountingDataService>();
builder.Services.AddScoped<ICountingDataRepository, CountingDataRepository>();
builder.Services.AddScoped<IStatDataService, StatDataService>();
builder.Services.AddScoped<IStatDataRepository, StatDataRepository>();

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
