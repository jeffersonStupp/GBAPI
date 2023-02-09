using GB.aplicacao;
using GB.dominio.Interfaces;
using GB.infra.Contexto;
using GB.infra.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GBAPI", Version = "v1" });
});
builder.Services.AddScoped<IUserServico, UserServico>();
builder.Services.AddScoped<IUserRepositorio, UserRepositorio>();

builder.Services.AddDbContext<UserContexto>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();