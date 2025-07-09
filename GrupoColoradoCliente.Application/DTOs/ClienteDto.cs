using SistemaCliente.Core.Enum;

namespace SistemaCliente.Application.DTOs
{
    public class ClienteDto
    {
        public string RazaoSocial { get; set; }
        public string? NomeFantasia { get; set; }        
        public TipoPessoa TipoPessoa { get; set; }
        public string Documento { get; set; }
        public string Endereco { get; set; }
        public string? Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
               
        public List<TelefoneDto> Telefones { get; set; } = new();
    }
}
