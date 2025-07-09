using SistemaCliente.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace SistemaCliente.Infrasctruture.Persistence
{
    public class SistemaClienteDbContext : DbContext
    {
       
            public SistemaClienteDbContext(DbContextOptions<SistemaClienteDbContext> options)
                : base(options)
            {
            }

            public DbSet<Cliente> Clientes { get; set; }
            public DbSet<Telefone> Telefones { get; set; }
            public DbSet<TiposTelefone> TiposTelefones { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {               
                modelBuilder.Entity<Telefone>()
                    .HasKey(t => new { t.CodigoCliente, t.NumeroTelefone });

                modelBuilder.Entity<Telefone>()
                    .Property(t => t.NumeroTelefone)
                    .HasMaxLength(20);

                modelBuilder.Entity<Telefone>()
                    .HasOne(t => t.Cliente)
                    .WithMany(c => c.Telefones)
                    .HasForeignKey(t => t.CodigoCliente)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Telefone>()
                    .HasOne(t => t.TiposTelefone)
                    .WithMany()
                    .HasForeignKey(t => t.CodigoTipoTelefone);

                modelBuilder.Entity<TiposTelefone>()
                    .Property(t => t.DescricaoTipoTelefone)
                    .HasMaxLength(100)
                    .IsRequired();

                modelBuilder.Entity<Cliente>()
                    .Property(c => c.RazaoSocial)
                    .HasMaxLength(200)
                    .IsRequired();

                
            }
            
        }
}
