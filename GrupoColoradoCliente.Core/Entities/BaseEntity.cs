using System.ComponentModel.DataAnnotations;

namespace SistemaCliente.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            DataInsercao = DateTime.Now;            
        }

        [Required]
        public DateTime DataInsercao { get; set; } = DateTime.Now;
        [Required]
        [StringLength(100)]
        public string UsuarioInsercao { get; set; } = "Sistema";
        public DateTime? DataAlteracao { get; set; } = DateTime.Now;
        [StringLength(100)]
        public string UsuarioAlteracao { get; set; } = "Sistema";
    }
}
