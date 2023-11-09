/// <summary>Classe responsavel por ser a classe de configuração da aplicação toda, como contexto, inicialização doswagger, inicialização da build do projeto, configuração 
/// da controller, services e interfaces, e também configuração da WebAplllication, e ambiente de desenvolvimento.
/// </summary>

using DesafioMeta.Entities.Context;
using DesafioMeta.Interface;
using DesafioMeta.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<DesafioDbContext>(options =>
{
    var connection = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connection);
});
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();

var app = builder.Build();

if( app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();


app.Run();
