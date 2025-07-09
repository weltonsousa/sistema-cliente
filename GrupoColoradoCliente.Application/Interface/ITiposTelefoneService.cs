using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;

namespace SistemaCliente.Application.Interface
{
    public interface ITipoTelefoneService
    {
        Task<IEnumerable<TipoTelefoneResponseDto>> GetAllAsync();
        Task<TipoTelefoneResponseDto?> GetByIdAsync(int id);
        Task<TipoTelefoneResponseDto> CreateAsync(TipoTelefoneDto dto);
        Task UpdateAsync(int id, TipoTelefoneDto dto);
        Task DeleteAsync(int id);
    }
}
