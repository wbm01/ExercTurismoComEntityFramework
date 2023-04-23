using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Turismo_EntityF.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Turismo_EntityFContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Turismo_EntityFContext") ?? throw new InvalidOperationException("Connection string 'Turismo_EntityFContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
