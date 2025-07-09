using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;
using WebAppMVC.Models;

namespace WebAppMVC.Mappers
{
    public static class TelefoneViewModelMapper
    {
                  
        public static TelefoneViewModel MapFromResponseDto(TelefoneResponseDto dto)
        {
            return new TelefoneViewModel
            {
                NumeroTelefone = dto.NumeroTelefone,
                Operadora = dto.Operadora,
                Ativo = dto.Ativo,
                CodigoTipoTelefone = dto.CodigoTipoTelefone,
                DescricaoTipoTelefone = dto.DescricaoTipoTelefone
            };
        }

       
        public static TelefoneDto MapToRequestDto(TelefoneViewModel model)
        {
            return new TelefoneDto
            {
                NumeroTelefone = model.NumeroTelefone,
                Operadora = model.Operadora,
                Ativo = model.Ativo,                
                CodigoTipoTelefone = model.CodigoTipoTelefone, 
                DescricaoTipoTelefone = model.DescricaoTipoTelefone 
            };
        }
    }

}


    
