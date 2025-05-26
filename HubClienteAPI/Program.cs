using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain.Commands.Handlers.Clientes.CadastrarCliente;
using ExternalServices.Interfaces;
using ExternalServices.Services;
using Domain.Services;
using Domain.Models.Validators.Clientes.CadastrarClienteValidator;
using Domain.Models.Validators.Clientes.ValidaCamposEnderecoValidator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddHttpClient<IViaCepService, ViaCepService>();
builder.Services.AddScoped<ExternalViaCepService>();
builder.Services.AddScoped<CadastrarClienteValidator>();
builder.Services.AddScoped<ValidaCamposEnderecoValidator>();

// builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CadastraClienteCommandHandler).Assembly));

builder.Services.AddDbContext<HubClienteContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
