using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCliente.Core.Entities;

namespace SistemaCliente.Infrasctruture.Persistence.Configurations
{
    public class TipoTelefoneConfiguration
    {
        public void Configure(EntityTypeBuilder<TiposTelefone> builder)
        {
           
            builder.Property(tt => tt.DescricaoTipoTelefone)
                .IsRequired()
                .HasMaxLength(50);
                       
        }
    }
}
