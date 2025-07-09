namespace WebAppMVC.Models
{
    public class TelefoneViewModel
    {
        public string NumeroTelefone { get; set; }
        public string Operadora { get; set; }
        public bool Ativo { get; set; }
        public int CodigoTipoTelefone { get; set; }
        
        public string? DescricaoTipoTelefone { get; set; }       
    }
}
