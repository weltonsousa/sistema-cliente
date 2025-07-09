using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class TipoTelefoneViewModel
    {
       
        [Required(ErrorMessage = "Descrição é obrigatória")]
        [StringLength(50, ErrorMessage = "Descrição deve ter no máximo 50 caracteres")]
        [Display(Name = "Descrição")]
        public string DescricaoTipoTelefone { get; set; } = string.Empty;
    }
}
