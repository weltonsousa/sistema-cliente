using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCliente.Core.Entities
{
    public class Telefone : BaseEntity
    {
               
        [Key, Column(Order = 0)]
        public int CodigoCliente { get; set; }
        [Key, Column(Order = 1)]
        [MaxLength(20)]
        public string NumeroTelefone { get; set; }
        public int CodigoTipoTelefone { get; set; }
        [MaxLength(50)]
        public string? Operadora { get; set; }
        public bool Ativo { get; set; }               
        public Cliente Cliente { get; set; }
        public TiposTelefone TiposTelefone { get; set; }

        
    }
}
