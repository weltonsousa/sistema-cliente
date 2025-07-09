using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;
using SistemaCliente.Application.Exceptions;
using SistemaCliente.Application.Interface;
using SistemaCliente.Application.Mappers;
using SistemaCliente.Core.Interfaces;

namespace SistemaCliente.Application.Service
{
    public class TipoTelefoneService : ITipoTelefoneService
    {
        private readonly ITipoTelefoneRepository _tipoTelefoneRepository;

        public TipoTelefoneService(ITipoTelefoneRepository tipoTelefoneRepository)
        {
            _tipoTelefoneRepository = tipoTelefoneRepository ?? throw new ArgumentNullException(nameof(tipoTelefoneRepository));
        }

        public async Task<IEnumerable<TipoTelefoneResponseDto>> GetAllAsync()
        {
            var tiposTelefones = await _tipoTelefoneRepository.GetAllAsync();

            return tiposTelefones.Select(TipoTelefoneMapper.MapToResponse);
        }

        public async Task<TipoTelefoneResponseDto?> GetByIdAsync(int id)
        {
            var tipoTelefone = await _tipoTelefoneRepository.GetByIdAsync(id);

            if (tipoTelefone == null)
                throw new NotFoundException("Tipo telefone não encontrado.");

            return TipoTelefoneMapper.MapToResponse(tipoTelefone);
        }

        public async Task<TipoTelefoneResponseDto> CreateAsync(TipoTelefoneDto dto)
        {
            var cliente = TipoTelefoneMapper.MapCreateDtoToEntity(dto);

            await _tipoTelefoneRepository.AddAsync(cliente);

            return TipoTelefoneMapper.MapToResponse(cliente);
        }

        public async Task UpdateAsync(int id, TipoTelefoneDto dto)
        {
            var oldTipoTelefone = await _tipoTelefoneRepository.GetByIdAsync(id);
            var tipo = oldTipoTelefone;

            if (tipo == null)
                throw new NotFoundException("Tipo não encontrado.");
                       
            await _tipoTelefoneRepository.UpdateAsync(tipo);
        }

        public async Task DeleteAsync(int id)
        {
            var tipo = await _tipoTelefoneRepository.GetByIdAsync(id);

            if (tipo == null)
                throw new NotFoundException("Tipo não encontrado.");

            await _tipoTelefoneRepository.DeleteAsync(tipo.CodigoTipoTelefone);
        }
      
    }

}
