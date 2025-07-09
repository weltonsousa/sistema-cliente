using SistemaCliente.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace SistemaCliente.Core.Entities
{
    public class Cliente : BaseEntity
    {
        [Key]
        public int CodigoCliente { get; set; }

        [Required, MaxLength(200)]
        public string RazaoSocial { get; set; }

        [MaxLength(200)]
        public string? NomeFantasia { get; set; }

        public TipoPessoa TipoPessoa { get; set; }

        [Required, MaxLength(20)]
        public string Documento { get; set; }

        [Required, MaxLength(300)]
        public string Endereco { get; set; }

        [MaxLength(100)]
        public string? Complemento { get; set; }

        [Required, MaxLength(100)]
        public string Bairro { get; set; }

        [Required, MaxLength(100)]
        public string Cidade { get; set; }

        [Required, MaxLength(10)]
        public string CEP { get; set; }

        [Required, MaxLength(2)]
        public string UF { get; set; }

        public bool Ativo { get; set; }      
        
        public List<Telefone> Telefones { get; set; } = new();       

    }

}
