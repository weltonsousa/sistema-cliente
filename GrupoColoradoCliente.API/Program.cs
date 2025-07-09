using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SistemaCliente.Application.Interface;
using SistemaCliente.Application.Service;
using SistemaCliente.Core.Interfaces;
using SistemaCliente.Infra.Seeds;
using SistemaCliente.Infrasctruture.Persistence;
using SistemaCliente.Infrasctruture.Repositories;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("ConnectionDb");
builder.Services.AddDbContext<SistemaClienteDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ITelefoneService, TelefoneService>();
builder.Services.AddScoped<ITipoTelefoneService, TipoTelefoneService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ITelefoneRepository, TelefoneRepository>();
builder.Services.AddScoped<ITipoTelefoneRepository, TiposTelefoneRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SistemaCliente.API", Version = "v1" });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<SistemaClienteDbContext>();
               
        context.Database.EnsureCreated();
       
        SeedData.Initialize(services, context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Erro ao executar seed data");
    }
}

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
