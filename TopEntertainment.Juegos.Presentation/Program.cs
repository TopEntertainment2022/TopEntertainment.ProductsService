using Microsoft.EntityFrameworkCore;
using TopEntertainment.Juegos.AccessData;
using TopEntertainment.Juegos.AccessData.Commands;
using TopEntertainment.Juegos.Application.Services;
using TopEntertainment.Juegos.Domain.Commands;

var builder = WebApplication.CreateBuilder(args);
var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
IConfiguration configuration = configBuilder.Build();
string connectionString = configuration.GetSection("ConnectionString").Value;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<JuegosContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddTransient<IJuegosRepository, JuegosRepository>();
builder.Services.AddTransient<IJuegosService, JuegosService>();

builder.Services.AddTransient<IPlataformaRepository, PlataformaRepository>();
builder.Services.AddTransient<IPlataformaService, PlataformaService>();

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
