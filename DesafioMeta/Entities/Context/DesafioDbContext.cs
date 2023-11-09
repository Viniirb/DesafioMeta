using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DesafioMeta.Entities.Context;
/// <summary>
/// Classe responsavel por iniciar, e gerenciar o contexto de dados.
/// </summary>
public class DesafioDbContext: DbContext
{
    /// <summary>
    /// Inicializando construtor com alguns parametros de configuração.
    /// </summary>
    /// <param name="options"></param>
    public DesafioDbContext(DbContextOptions<DesafioDbContext> options) : base(options)
    {}

    /// <summary>
    /// Inicializando construtor vazio.
    /// </summary>
    public DesafioDbContext() { }

    /// <summary>
    /// Adicionando referencia as entidades do sistema.
    /// </summary>
    public DbSet<Pessoa> Pessoa { get; set; }
    public DbSet<Endereco> Endereco { get; set;}

    /// <summary>
    /// Configuração do Contexto de dados, e configuração da conexão com o banco de dados.
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                   .SetBasePath(Directory
                                                   .GetCurrentDirectory())
                                                   .AddJsonFile("appsettings.json")
                                                   .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    /// <summary>
    /// Inicialização do mapeamento das colunas e tabelas de cada entidade do sistema.
    /// </summary>
    /// <param name="modelBuilder"></param>

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pessoa>().Property(typeof(int), "Id").IsRequired();
        modelBuilder.Entity<Pessoa>().Property(typeof(string), "Nome").HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Pessoa>().Property(typeof(int), "Idade").IsRequired();
        modelBuilder.Entity<Pessoa>().Property(typeof(string), "CPF").HasMaxLength(14);
        modelBuilder.Entity<Pessoa>().Property(typeof(string), "Email").HasMaxLength(100);
        modelBuilder.Entity<Pessoa>().Property(typeof(string), "Nacionalidade").HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Pessoa>().Property(typeof(string), "Genero").HasMaxLength(100).IsRequired();
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Endereco>().Property(typeof(int), "Id").IsRequired();
        modelBuilder.Entity<Endereco>().Property(typeof(int), "PessoaId").IsRequired();
        modelBuilder.Entity<Endereco>().Property(typeof(string), "Logradouro").HasMaxLength(100).IsRequired(); 
        modelBuilder.Entity<Endereco>().Property(typeof(string), "Numero").HasMaxLength(10);
        modelBuilder.Entity<Endereco>().Property(typeof(string), "Complemento").HasMaxLength(100);
        modelBuilder.Entity<Endereco>().Property(typeof(string), "Cidade").HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Endereco>().Property(typeof(string), "Bairro").HasMaxLength(100);
        modelBuilder.Entity<Endereco>().Property(typeof(string), "Estado").HasMaxLength(100);
        modelBuilder.Entity<Endereco>().Property(typeof(string), "CodigoPostal").HasMaxLength(10);
        base.OnModelCreating(modelBuilder);
    }
}

