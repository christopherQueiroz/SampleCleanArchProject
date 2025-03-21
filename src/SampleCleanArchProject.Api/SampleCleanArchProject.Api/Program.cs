using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SampleCleanArchProject.Infra.Data.Context;
using SampleCleanArchProject.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Configurar para o Kestrel escutar na porta 80 e em todas as interfaces
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80); // A API vai escutar na porta 80
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddInfrastructureJwt(builder.Configuration);
builder.Services.AddInfrastructureSwagger();

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
