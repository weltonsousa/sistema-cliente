using SistemaCliente.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaCliente.Infrasctruture.Persistence.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.CodigoCliente);

            builder.Property(c => c.RazaoSocial)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.NomeFantasia)
                .HasMaxLength(200);

            builder.Property(c => c.Documento)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Endereco)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(c => c.Complemento)
                .HasMaxLength(100);

            builder.Property(c => c.Bairro)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Cidade)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.CEP)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(c => c.UF)
                .IsRequired()
                .HasMaxLength(2);

            builder.HasIndex(c => c.Documento)
                   .IsUnique();               
                   
            builder.HasMany(c => c.Telefones)
                .WithOne(t => t.Cliente)
                .HasForeignKey(t => t.CodigoCliente)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
