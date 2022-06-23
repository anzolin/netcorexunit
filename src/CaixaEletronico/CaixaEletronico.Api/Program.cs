using CaixaEletronico.Domain;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICaixa, Caixa>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapPost("/saque/{valor}", ([FromServices] ICaixa caixa, int valor) =>
{
    if (!caixa.ValidaCedulasDisponiveis(valor))
        return Results.BadRequest("Valor não válido para saque. Notas disponíveis: 100, 50, 20 e 10");

    return Results.Ok($"Receba seu saque: { string.Join(',', caixa.Saque(valor)) }");
});

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();

public partial class Program { }