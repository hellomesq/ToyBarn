using LojaBrinquedos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=brinquedos.db"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ToyBarn API",
        Version = "v1",
        Description = "API CRUD para gerenciar brinquedos da loja ToyBarn \n" +
                      "Esta API permite listar, criar, atualizar e deletar brinquedos na tabela TDS_TB_Brinquedos, incluindo informações como nome, tipo, classificação, tamanho e preço.",
        License = new OpenApiLicense
        {
            Name = "License: MIT",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToyBarn API V1");
    c.RoutePrefix = string.Empty; 
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
