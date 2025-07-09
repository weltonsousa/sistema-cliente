using Microsoft.EntityFrameworkCore;
using SistemaCliente.Core.Entities;
using SistemaCliente.Core.Interfaces;
using SistemaCliente.Infrasctruture.Persistence;

namespace SistemaCliente.Infrasctruture.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SistemaClienteDbContext _context;

        public ClienteRepository(SistemaClienteDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes
                .Include(c => c.Telefones)
                    .ThenInclude(t => t.TiposTelefone)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _context.Clientes
                .Include(c => c.Telefones)
                    .ThenInclude(t => t.TiposTelefone)
                .FirstOrDefaultAsync(c => c.CodigoCliente == id);
        }

        public async Task AddAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
        
    }
}
