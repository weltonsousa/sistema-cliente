using System.ComponentModel.DataAnnotations;

namespace SistemaCliente.Core.Entities
{
    public class TiposTelefone : BaseEntity
    {
        [Key]
        public int CodigoTipoTelefone { get; set; }
        [Required, MaxLength(100)]
        public string DescricaoTipoTelefone { get; set; }
        public bool Ativo { get; set; }      
    }

    public static class TiposPadrao
    {
        public const string RESIDENCIAL = "RESIDENCIAL";
        public const string COMERCIAL = "COMERCIAL";
        public const string WHATSAPP = "WHATSAPP";
        public const string RECADO = "RECADO";
    }
}
