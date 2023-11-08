using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DesafioMeta.Entities.Context;
public class DesafioDbContext: DbContext
{
    public DesafioDbContext(DbContextOptions<DesafioDbContext> options) : base(options)
    {}

    public DesafioDbContext() { }

    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Endereco> Enderecos { get; set;}

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
}

