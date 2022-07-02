using Microsoft.EntityFrameworkCore;
using TopEntertainment.Juegos.AccessData;
using TopEntertainment.Juegos.AccessData.Commands;
using TopEntertainment.Juegos.Application.Services;
using TopEntertainment.Juegos.Domain.Commands;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
IConfiguration configuration = configBuilder.Build();
string connectionString = configuration.GetSection("ConnectionString").Value;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<JuegosContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddTransient<IJuegosRepository, JuegosRepository>();
builder.Services.AddTransient<IJuegosService, JuegosService>();

builder.Services.AddTransient<IPlataformaRepository, PlataformaRepository>();
builder.Services.AddTransient<IPlataformaService, PlataformaService>();

builder.Services.AddTransient<IClasificacionRepository, ClasificacionRepository>();
builder.Services.AddTransient<IClasificacionService, ClasificacionService>();

builder.Services.AddTransient<ICategoriaRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoriaService, CategoriaService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://127.0.0.1:5500")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();