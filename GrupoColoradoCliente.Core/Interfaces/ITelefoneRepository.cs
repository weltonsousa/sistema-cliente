using SistemaCliente.Core.Entities;

namespace SistemaCliente.Core.Interfaces
{
    public interface ITelefoneRepository
    {
        Task<IEnumerable<Telefone>> GetAllAsync();
        Task<Telefone> GetByIdAsync(int id);
        Task AddAsync(Telefone telefone);
        Task UpdateAsync(Telefone telefone);
        Task DeleteAsync(int id);
    }
}
