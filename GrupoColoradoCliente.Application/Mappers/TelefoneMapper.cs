using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;
using SistemaCliente.Core.Entities;

namespace SistemaCliente.Application.Mappers
{
    public class TelefoneMapper
    {
        public static Telefone MapCreateDtoToEntity(TelefoneDto createDto)
        {
            return new Telefone
            {                
                NumeroTelefone = createDto.NumeroTelefone,                
                Operadora = createDto.Operadora,
                Ativo = createDto.Ativo               

            };
        }

        public static TelefoneResponseDto MapToResponse(Telefone telefone)
        {
            return new TelefoneResponseDto
            {
                NumeroTelefone = telefone.NumeroTelefone,
                Operadora = telefone.Operadora,
                Ativo = telefone.Ativo,
                CodigoCliente = telefone.CodigoCliente,
                CodigoTipoTelefone = telefone.CodigoTipoTelefone,
                DescricaoTipoTelefone = telefone.TiposTelefone?.DescricaoTipoTelefone
            };
        }
        
        public static TelefoneDto MapEntityToDto(Telefone telefone)
        {
            return new TelefoneDto
            {               
                NumeroTelefone = telefone.NumeroTelefone,            
                Operadora = telefone.Operadora,
                Ativo = telefone.Ativo,                           
            };
        }
               
    }
}
