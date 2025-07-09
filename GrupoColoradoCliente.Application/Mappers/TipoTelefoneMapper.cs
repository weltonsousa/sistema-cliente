using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;
using SistemaCliente.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCliente.Application.Mappers
{
    public static class TipoTelefoneMapper
    {
        public static TipoTelefoneDto MapEntityToDto(TiposTelefone entity)
        {
            return new TipoTelefoneDto
            {
                             
                DescricaoTipoTelefone = entity.DescricaoTipoTelefone,
                Ativo = entity.Ativo,             
            };
        }

        public static TipoTelefoneResponseDto MapToResponse(TiposTelefone tipoTelefone)
        {
            return new TipoTelefoneResponseDto
            {
                CodigoTipoTelefone = tipoTelefone.CodigoTipoTelefone,
                DescricaoTipoTelefone = tipoTelefone.DescricaoTipoTelefone
            };
        }

        public static TiposTelefone MapCreateDtoToEntity(TipoTelefoneDto dto)
        {
            return new TiposTelefone
            {
                DescricaoTipoTelefone = dto.DescricaoTipoTelefone,               
                Ativo = dto.Ativo,               
            };
        }
       
    }
}
