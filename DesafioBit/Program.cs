using DesafioBit.Application.Interfaces.Repositories;
using DesafioBit.Application.Interfaces.Services;
using DesafioBit.Application.Services;
using DesafioBit.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddSingleton<IProdutoService, ProdutoService>();
builder.Services.AddSingleton<IProdutoRepository, ProdutoRepository>();
builder.Services.AddSingleton<IGarantiaService, GarantiaService>();
builder.Services.AddSingleton<IGarantiaRepository, GarantiaRepository>();
builder.Services.AddSingleton<IVendaService, VendaService>();
builder.Services.AddSingleton<IVendaRepository, VendaRepository>();

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
