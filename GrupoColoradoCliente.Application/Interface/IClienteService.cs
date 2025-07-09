using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;

namespace SistemaCliente.Application.Interface
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteResponseDto>> GetAllAsync();
        Task<ClienteResponseDto> GetByIdAsync(int id);
        Task<int> CreateAsync(ClienteDto dto);
        Task UpdateAsync(int id, ClienteDto dto);
        Task DeleteAsync(int id);
       
    }
}
