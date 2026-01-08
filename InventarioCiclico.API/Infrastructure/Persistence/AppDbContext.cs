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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //Schema do banco
        modelBuilder.HasDefaultSchema("JBS");
        base.OnModelCreating(modelBuilder);
    }
    
}
