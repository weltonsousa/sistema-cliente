using SistemaCliente.Core.Entities;

namespace SistemaCliente.Core.Interfaces
{
    public interface ITipoTelefoneRepository
    {
        Task<IEnumerable<TiposTelefone>> GetAllAsync();
        Task<TiposTelefone> GetByIdAsync(int id);
        Task AddAsync(TiposTelefone TipoTelefone);
        Task UpdateAsync(TiposTelefone TipoTelefone);
        Task DeleteAsync(int id);
    }
}
