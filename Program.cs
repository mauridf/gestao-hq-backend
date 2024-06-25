using gestao_hq_backend.Application.Interfaces;
using gestao_hq_backend.Application.Services;
using gestao_hq_backend.Infrastructure.Data;
using gestao_hq_backend.Infrastructure.Data.Repositories;
using gestao_hq_backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar o DbContext com PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar repositórios
builder.Services.AddScoped<IEditoraRepository, EditoraRepository>();
builder.Services.AddScoped<IPersonagemRepository, PersonagemRepository>();
builder.Services.AddScoped<IEdicaoRepository, EdicaoRepository>();
builder.Services.AddScoped<IHqRepository, HqRepository>();
builder.Services.AddScoped<IHqEditoraRepository, HqEditoraRepository>();
builder.Services.AddScoped<IHqPersonagemRepository, HqPersonagemRepository>();

// Registrar serviços
builder.Services.AddScoped<EditoraService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.MapControllers();

app.Run();