using Grupo_6_CE_LN.Models;
using Microsoft.EntityFrameworkCore;

#region Configuracion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CasoEstudioContext>(op =>
    op.UseSqlServer(builder.Configuration.GetConnectionString("PA1Context"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
#endregion

app.Run();
