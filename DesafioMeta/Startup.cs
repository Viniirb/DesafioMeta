using DesafioMeta.Entities.Context;
using Microsoft.OpenApi.Models;

namespace DesafioMeta;
public class Startup
{
    /// <summary>
    /// Classe de inicilização e configuração da aplicação
    /// </summary>
    /// <param name="configuration"></param>
    
    ///Inicalizando Construtor da classe
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    /// <summary>
    /// Inicializdno variavel de configuração.
    /// </summary>
    public IConfiguration Configuration { get; }

    /// <summary>
    /// Método responsavel por configura alguns serviços da aplicação
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<DesafioDbContext>();
        services.AddControllers();

        services.AddSwaggerGen(x =>
        {
            x.SwaggerDoc("v1", new OpenApiInfo { Title = "DesafioMeta", Version = "v1" });
        });
    }

    /// <summary>
    /// Método responsavel por configurar o pipeline de requisição da aplicação
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DesafioMeta v1"));
        }

        app.UseRouting();

        app.UseEndpoints(end =>
        {
            end.MapControllers();
        });
    }
}