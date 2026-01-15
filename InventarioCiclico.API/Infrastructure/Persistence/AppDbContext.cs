using InventarioCiclico.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace InventarioCiclico.API.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {      
    }

    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Log> Log { get; set; }
    public DbSet<Cadastro> Cadastro { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //Schema do banco
        modelBuilder.HasDefaultSchema("JBS");
       
        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Sequencia);
            entity.Property(e => e.Sequencia)
                .HasColumnName("SEQUENCIA")
                .ValueGeneratedOnAdd() // Indica que o valor é gerado no momento da adição
                .HasDefaultValueSql("SEQ_PATRIMONIO_LOG.NEXTVAL"); // Usa a sequência Oracle

            entity.HasKey(e => e.Sequencia);

        });

        base.OnModelCreating(modelBuilder);
    }
    
}
