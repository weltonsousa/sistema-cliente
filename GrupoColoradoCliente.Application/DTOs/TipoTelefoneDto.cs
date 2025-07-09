using System.ComponentModel.DataAnnotations;

namespace SistemaCliente.Application.DTOs
{
    public class TipoTelefoneDto
    {       

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(50, ErrorMessage = "A descrição deve ter no máximo 50 caracteres.")]
        public string? DescricaoTipoTelefone { get; set; }
        public bool Ativo { get; set; }
    }
}
