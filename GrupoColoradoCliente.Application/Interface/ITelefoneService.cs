using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;

namespace SistemaCliente.Application.Interface
{
    public interface ITelefoneService
    {
        Task<IEnumerable<TelefoneResponseDto>> GetAllAsync();
        Task<TelefoneResponseDto?> GetByIdAsync(int id);
        Task<TelefoneResponseDto> CreateAsync(TelefoneDto dto);
        Task UpdateAsync(int id, TelefoneDto dto);
        Task DeleteAsync(int id);
    }
}
