using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCliente.Application.DTOs.Response
{
    public class TelefoneResponseDto
    {
        public string NumeroTelefone { get; set; }
        public string Operadora { get; set; }
        public bool Ativo { get; set; }
        public int CodigoCliente { get; set; }
        public int CodigoTipoTelefone { get; set; }
        public string DescricaoTipoTelefone { get; set; }

    }
}
