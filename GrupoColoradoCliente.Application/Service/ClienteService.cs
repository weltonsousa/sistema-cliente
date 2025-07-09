using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;
using SistemaCliente.Application.Exceptions;
using SistemaCliente.Application.Interface;
using SistemaCliente.Application.Mappers;
using SistemaCliente.Core.Entities;
using SistemaCliente.Core.Interfaces;

namespace SistemaCliente.Application.Service
{
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<ClienteResponseDto>> GetAllAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return clientes.Select(ClienteMapper.MapToResponse);
        }

        public async Task<ClienteResponseDto> GetByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
                throw new NotFoundException("Cliente não encontrado");

            return ClienteMapper.MapToResponse(cliente);
        }

        public async Task<int> CreateAsync(ClienteDto dto)
        {
            var cliente = new Cliente
            {
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
                Ativo = true,
                UsuarioAlteracao = "Sistema", 
                DataAlteracao = DateTime.Now,
                Telefones = dto.Telefones.Select(t => new Telefone
                {
                    NumeroTelefone = t.NumeroTelefone,
                    CodigoTipoTelefone = t.CodigoTipoTelefone,
                    Operadora = t.Operadora,
                    Ativo = t.Ativo,
                    UsuarioAlteracao = "Sistema", 
                    DataAlteracao = DateTime.Now
                }).ToList()
            };

            await _clienteRepository.AddAsync(cliente);
            return cliente.CodigoCliente;
        }

        public async Task UpdateAsync(int id, ClienteDto dto)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
                throw new NotFoundException("Cliente não encontrado");

            cliente.RazaoSocial = dto.RazaoSocial;
            cliente.NomeFantasia = dto.NomeFantasia;
            cliente.TipoPessoa = dto.TipoPessoa;
            cliente.Documento = dto.Documento;
            cliente.Endereco = dto.Endereco;
            cliente.Complemento = dto.Complemento;
            cliente.Bairro = dto.Bairro;
            cliente.Cidade = dto.Cidade;
            cliente.CEP = dto.CEP;
            cliente.UF = dto.UF;
            cliente.DataAlteracao = DateTime.Now;
            cliente.UsuarioAlteracao = "Sistema"; 
                       
            cliente.Telefones.Clear();
            foreach (var t in dto.Telefones)
            {
                cliente.Telefones.Add(new Telefone
                {
                    NumeroTelefone = t.NumeroTelefone,
                    CodigoTipoTelefone = t.CodigoTipoTelefone,
                    Operadora = t.Operadora,
                    Ativo = t.Ativo,
                    DataAlteracao = DateTime.Now,
                    UsuarioAlteracao = "Sistema", 
                });
            }

            await _clienteRepository.UpdateAsync(cliente);
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
                throw new NotFoundException("Cliente não encontrado");

            await _clienteRepository.DeleteAsync(cliente);
        }
    }   
}
