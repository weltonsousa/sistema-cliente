using System.Text.Json.Serialization;

namespace SistemaCliente.Application.DTOs
{
    public class TelefoneDto
    {
        public int CodigoCliente { get; set; }
        public string NumeroTelefone { get; set; }
        public int CodigoTipoTelefone { get; set; }
        public string DescricaoTipoTelefone { get; set; }
        public string Operadora { get; set; }
        public bool Ativo { get; set; }               
       
        [JsonIgnore]
        public ClienteDto? Cliente { get; set; }
    }

}
