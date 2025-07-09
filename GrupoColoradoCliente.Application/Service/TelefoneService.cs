using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;
using SistemaCliente.Application.Exceptions;
using SistemaCliente.Application.Interface;
using SistemaCliente.Application.Mappers;
using SistemaCliente.Core.Interfaces;

namespace SistemaCliente.Application.Service
{
    public class TelefoneService : ITelefoneService
    {
        private readonly ITelefoneRepository _telefoneRepository;

        public TelefoneService(ITelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository ?? throw new ArgumentNullException(nameof(telefoneRepository));
        }

        public async Task<IEnumerable<TelefoneResponseDto>> GetAllAsync()
        {
            var telefones = await _telefoneRepository.GetAllAsync();

            return telefones.Select(TelefoneMapper.MapToResponse);
        }

        public async Task<TelefoneResponseDto?> GetByIdAsync(int id)
        {
            var telefone = await _telefoneRepository.GetByIdAsync(id);

            if (telefone == null)
                throw new NotFoundException("Telefone não encontrado.");

            return TelefoneMapper.MapToResponse(telefone);
        }

        public async Task<TelefoneResponseDto> CreateAsync(TelefoneDto dto)
        {
            var telefone = TelefoneMapper.MapCreateDtoToEntity(dto);

            await _telefoneRepository.AddAsync(telefone);

            return TelefoneMapper.MapToResponse(telefone);
        }

        public async Task UpdateAsync(int id, TelefoneDto dto)
        {
            var oldTelefone = await _telefoneRepository.GetByIdAsync(id);
            var telefone = oldTelefone;

            if (telefone == null)
                throw new NotFoundException("Telefone não encontrado.");

            telefone.NumeroTelefone = dto.NumeroTelefone;
            telefone.Operadora = dto.Operadora;
            
            await _telefoneRepository.UpdateAsync(telefone);
        }

        public async Task DeleteAsync(int id)
        {
            var telefone = await _telefoneRepository.GetByIdAsync(id);

            if (telefone == null)
                throw new NotFoundException("Telefone não encontrado.");

            await _telefoneRepository.DeleteAsync(telefone.CodigoTipoTelefone);
        }
    }
  
}

