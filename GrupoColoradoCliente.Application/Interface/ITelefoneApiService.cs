using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;

namespace SistemaCliente.Application.Interface
{
    public interface ITelefoneApiService
    {
        Task<ApiResponse<IEnumerable<TelefoneResponseDto>>> GetAllAsync();
        Task<ApiResponse<TelefoneResponseDto>> GetByIdAsync(int id);
        Task<ApiResponse<TelefoneResponseDto>> CreateAsync(TelefoneDto dto);
        Task<ApiResponse<bool>> UpdateAsync(int id, TelefoneDto dto);
        Task<ApiResponse<bool>> DeleteAsync(int id);
    }

}