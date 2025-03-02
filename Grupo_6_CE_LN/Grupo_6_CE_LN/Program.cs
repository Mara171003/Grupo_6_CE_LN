using Grupo_6_CE_LN.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configurar conexión a la base de datos SQL Server
builder.Services.AddDbContext<CasoEstudioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar servicios de controladores
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Configurar Swagger para documentación de API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API de Usuarios", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Usuarios v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapControllers(); // ?? Esto mapea todos los controladores automáticamente

app.Run();