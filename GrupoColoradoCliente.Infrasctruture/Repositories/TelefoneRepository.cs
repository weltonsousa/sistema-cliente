using Microsoft.EntityFrameworkCore;
using SistemaCliente.Core.Entities;
using SistemaCliente.Core.Interfaces;
using SistemaCliente.Infrasctruture.Persistence;

namespace SistemaCliente.Infrasctruture.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly SistemaClienteDbContext _context;

        public TelefoneRepository(SistemaClienteDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Telefone telefone)
        {
            try
            {
                if (telefone == null)
                    throw new ArgumentNullException(nameof(telefone));

                await _context.Telefones.AddAsync(telefone);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao adicionar telefone: {ex.Message}", ex);
            }
        }
              
        public async Task<IEnumerable<Telefone>> GetAllAsync()
        {
            try
            {
                return await _context.Telefones
                    .Include(t => t.Cliente)
                    .Include(t => t.TiposTelefone)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar todos os telefones: {ex.Message}", ex);
            }
        }

        public async Task<Telefone> GetByIdAsync(int id)
        {
            try
            {
                var telefone = await _context.Telefones
                    .Include(t => t.Cliente)
                    .Include(t => t.TiposTelefone)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(t => t.CodigoCliente == id);

                if (telefone == null)
                    throw new KeyNotFoundException($"Telefone com ID {id} não encontrado.");

                return telefone;
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar telefone por ID: {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(Telefone telefone)
        {
            try
            {
                if (telefone == null)
                    throw new ArgumentNullException(nameof(telefone));

                var telefoneExistente = await _context.Telefones
                    .FirstOrDefaultAsync(t => t.CodigoCliente == telefone.CodigoCliente);

                if (telefoneExistente == null)
                    throw new KeyNotFoundException($"Telefone com ID {telefone.CodigoCliente} não encontrado.");
               
                _context.Telefones.Update(telefoneExistente);
                await _context.SaveChangesAsync();
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar telefone: {ex.Message}", ex);
            }
        }
               
        public async Task<IEnumerable<Telefone>> GetTelefonesPorClienteAsync(int clienteId)
        {
            try
            {
                return await _context.Telefones
                    .Include(t => t.TiposTelefone)
                    .Where(t => t.CodigoCliente == clienteId)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar telefones por cliente: {ex.Message}", ex);
            }
        }
            
        public async Task<IEnumerable<Telefone>> GetTelefonesAtivosPorClienteAsync(int clienteId)
        {
            try
            {
                return await _context.Telefones
                    .Include(t => t.TiposTelefone)
                    .Where(t => t.CodigoCliente == clienteId && t.Ativo)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar telefones ativos por cliente: {ex.Message}", ex);
            }
        }

        public async Task<bool> RemoverTelefoneDoClienteAsync(int clienteId, int telefoneId)
        {
            try
            {
                var telefone = await _context.Telefones
                    .FirstOrDefaultAsync(t => t.CodigoCliente == telefoneId && t.CodigoCliente == clienteId);

                if (telefone == null)
                    return false;

                _context.Telefones.Remove(telefone);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao remover telefone do cliente: {ex.Message}", ex);
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            try
            {
                return await _context.Telefones
                    .AsNoTracking()
                    .AnyAsync(t => t.CodigoCliente == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar se telefone existe: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Telefone>> GetTelefonesPorNumeroAsync(string numero)
        {
            try
            {
                return await _context.Telefones
                    .Include(t => t.Cliente)
                    .Include(t => t.TiposTelefone)
                    .Where(t => t.NumeroTelefone.Contains(numero))
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar telefones por número: {ex.Message}", ex);
            }
        }

        public async Task<bool> NumeroExisteAsync(string numero)
        {
            try
            {
                return await _context.Telefones
                    .AsNoTracking()
                    .AnyAsync(t => t.NumeroTelefone == numero);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar se número existe: {ex.Message}", ex);
            }
        }

        public async Task<int> CountTelefonesPorClienteAsync(int clienteId)
        {
            try
            {
                return await _context.Telefones
                    .AsNoTracking()
                    .CountAsync(t => t.CodigoCliente == clienteId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao contar telefones por cliente: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Telefone>> GetTelefonesComFiltroAsync(int? clienteId = null, int? TipoTelefoneId = null, bool? ativo = null)
        {
            try
            {
                var query = _context.Telefones
                    .Include(t => t.Cliente)
                    .Include(t => t.TiposTelefone)
                    .AsNoTracking()
                    .AsQueryable();

                if (clienteId.HasValue)
                    query = query.Where(t => t.CodigoCliente == clienteId.Value);

                if (TipoTelefoneId.HasValue)
                    query = query.Where(t => t.CodigoCliente == TipoTelefoneId.Value);

                if (ativo.HasValue)
                    query = query.Where(t => t.Ativo == ativo.Value);

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar telefones com filtro: {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var telefone = await _context.Telefones.FindAsync(id);
                if (telefone == null)
                    throw new KeyNotFoundException($"Telefone com ID {id} não encontrado.");

                telefone.Ativo = false;
                _context.Telefones.Update(telefone);
                await _context.SaveChangesAsync();
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao desativar telefone: {ex.Message}", ex);
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
