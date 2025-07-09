using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCliente.Application.Interface
{
    public interface ITipoTelefoneApiService
    {
        Task<ApiResponse<IEnumerable<TipoTelefoneResponseDto>>> GetAllAsync();
        Task<ApiResponse<TipoTelefoneResponseDto>> GetByIdAsync(int id);
        Task<ApiResponse<TipoTelefoneResponseDto>> CreateAsync(TipoTelefoneDto dto);
        Task<ApiResponse<bool>> UpdateAsync(int id, TipoTelefoneDto dto);
        Task<ApiResponse<bool>> DeleteAsync(int id);
    }

}