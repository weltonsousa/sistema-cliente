using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;
using SistemaCliente.Core.Entities;

namespace SistemaCliente.Application.Mappers
{
    public class ClienteMapper
    {
        #region Mapper Methods

        public static ClienteResponseDto MapToResponse(Cliente cliente)
        {
            return new ClienteResponseDto
            {
                CodigoCliente = cliente.CodigoCliente,
                RazaoSocial = cliente.RazaoSocial,
                NomeFantasia = cliente.NomeFantasia,
                TipoPessoa = cliente.TipoPessoa,
                Documento = cliente.Documento,
                Endereco = cliente.Endereco,
                Complemento = cliente.Complemento,
                Bairro = cliente.Bairro,
                Cidade = cliente.Cidade,
                CEP = cliente.CEP,
                UF = cliente.UF,
                Ativo = cliente.Ativo,
                Telefones = cliente.Telefones?.Select(TelefoneMapper.MapToResponse).ToList() ?? new()
            };
         }
        public static Cliente MapCreateDtoToEntity(ClienteDto createDto)
        {
            return new Cliente
            {
                RazaoSocial = createDto.RazaoSocial,
                NomeFantasia = createDto.NomeFantasia,
                TipoPessoa = createDto.TipoPessoa,
                Documento = createDto.Documento,
                Endereco = createDto.Endereco,
                Complemento = createDto.Complemento,
                Bairro = createDto.Bairro,
                Cidade = createDto.Cidade,
                CEP = createDto.CEP,
                UF = createDto.UF
            };
        }

        public static ClienteDto MapEntityToDto(Cliente cliente)
        {
            return new ClienteDto
            {                
                RazaoSocial = cliente.RazaoSocial,
                NomeFantasia = cliente.NomeFantasia,
                TipoPessoa = cliente.TipoPessoa,
                Documento = cliente.Documento,
                Endereco = cliente.Endereco,
                Complemento = cliente.Complemento,
                Bairro = cliente.Bairro,
                Cidade = cliente.Cidade,
                CEP = cliente.CEP,
                UF = cliente.UF,
                Telefones = cliente.Telefones?.Select(MapToDto).ToList() ?? new List<TelefoneDto>()
            };
        }


        public static TelefoneDto MapToDto(Telefone telefone)
        {
            return new TelefoneDto
            {
                NumeroTelefone = telefone.NumeroTelefone,
                Operadora = telefone.Operadora,
                Ativo = telefone.Ativo,
                CodigoCliente = telefone.CodigoCliente,
                CodigoTipoTelefone = telefone.CodigoTipoTelefone,
                DescricaoTipoTelefone = telefone.TiposTelefone?.DescricaoTipoTelefone
            };
        }


        #endregion
    }
}
