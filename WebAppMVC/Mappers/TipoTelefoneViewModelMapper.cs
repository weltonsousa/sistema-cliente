using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;
using WebAppMVC.Models;

namespace WebAppMVC.Mappers
{
    public static class TipoTelefoneViewModelMapper
    {
        public static TipoTelefoneViewModel MapFromResponseDto(TipoTelefoneResponseDto dto)
        {
            return new TipoTelefoneViewModel
            {                
                DescricaoTipoTelefone = dto.DescricaoTipoTelefone
            };
        }

        public static TipoTelefoneDto MapToRequestDto(TipoTelefoneViewModel model)
        {
            return new TipoTelefoneDto
            {               
                DescricaoTipoTelefone = model.DescricaoTipoTelefone
            };
        }
                
    }

}
