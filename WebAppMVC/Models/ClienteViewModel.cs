using SistemaCliente.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class ClienteViewModel
    {
        public int CodigoCliente { get; set; }
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
        public bool Ativo { get; set; }

        public List<TelefoneViewModel> Telefones { get; set; } = new();
    }

}