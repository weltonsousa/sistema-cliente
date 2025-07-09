using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCliente.Application.Interface
{
    public interface  IClienteApiService
    {
        Task<ApiResponse<IEnumerable<ClienteResponseDto>>> GetAllAsync();
        Task<ApiResponse<ClienteResponseDto>> GetByIdAsync(int id);
        Task<ApiResponse<ClienteResponseDto>> CreateAsync(ClienteDto dto);
        Task<ApiResponse<bool>> UpdateAsync(int id, ClienteDto dto);
        Task<ApiResponse<bool>> DeleteAsync(int id);
    }

}