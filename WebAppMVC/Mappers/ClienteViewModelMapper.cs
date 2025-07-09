using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;
using WebAppMVC.Models;

namespace WebAppMVC.Mappers
{
    public static class ClienteViewModelMapper
    {      
            
        public static ClienteViewModel MapFromResponseDto(ClienteResponseDto dto)
        {
            return new ClienteViewModel
            {
                CodigoCliente = dto.CodigoCliente,
                RazaoSocial = dto.RazaoSocial,
                NomeFantasia = dto.NomeFantasia,
                TipoPessoa = dto.TipoPessoa,
                Documento = dto.Documento,
                Endereco = dto.Endereco,
                Complemento = dto.Complemento,
                Bairro = dto.Bairro,
                Cidade = dto.Cidade,
                CEP = dto.CEP,
                UF = dto.UF,
                Ativo = dto.Ativo,
                Telefones = dto.Telefones?.Select(TelefoneViewModelMapper.MapFromResponseDto).ToList() ?? new()
            };
        }
                   
        public static ClienteDto MapToRequestDto(ClienteViewModel model)
        {
            return new ClienteDto
            {
                RazaoSocial = model.RazaoSocial,
                NomeFantasia = model.NomeFantasia,
                TipoPessoa = model.TipoPessoa,
                Documento = model.Documento,
                Endereco = model.Endereco,
                Complemento = model.Complemento,
                Bairro = model.Bairro,
                Cidade = model.Cidade,
                CEP = model.CEP,
                UF = model.UF,                   
                Telefones = model.Telefones?.Select(TelefoneViewModelMapper.MapToRequestDto).ToList() ?? new()
            };
        }
    }

}

