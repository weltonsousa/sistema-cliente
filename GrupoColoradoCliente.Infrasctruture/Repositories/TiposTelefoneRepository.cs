using Microsoft.EntityFrameworkCore;
using SistemaCliente.Core.Entities;
using SistemaCliente.Core.Interfaces;
using SistemaCliente.Infrasctruture.Persistence;

namespace SistemaCliente.Infrasctruture.Repositories
{
    public class TiposTelefoneRepository : ITipoTelefoneRepository
    {

        private readonly SistemaClienteDbContext _context;

        public TiposTelefoneRepository(SistemaClienteDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(TiposTelefone tipoTelefone)
        {
            try
            {
                if (tipoTelefone == null)
                    throw new ArgumentNullException(nameof(tipoTelefone));

                await _context.TiposTelefones.AddAsync(tipoTelefone);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao adicionar tipo de telefone: {ex.Message}", ex);
            }
        }


        public async Task<IEnumerable<TiposTelefone>> GetAllAsync()
        {
            try
            {
                return await _context.TiposTelefones
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar todos os tipos de telefone: {ex.Message}", ex);
            }
        }

        public async Task<TiposTelefone> GetByIdAsync(int id)
        {
            try
            {
                var tipoTelefone = await _context.TiposTelefones
                    .FirstOrDefaultAsync(t => t.CodigoTipoTelefone == id);

                if (tipoTelefone == null)
                    throw new KeyNotFoundException($"Tipo de telefone com ID {id} não encontrado.");

                return tipoTelefone;
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar tipo de telefone por ID: {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(TiposTelefone tipoTelefone)
        {
            try
            {
                if (tipoTelefone == null)
                    throw new ArgumentNullException(nameof(tipoTelefone));

                var tipoExistente = await _context.TiposTelefones
                    .FirstOrDefaultAsync(t => t.CodigoTipoTelefone == tipoTelefone.CodigoTipoTelefone);

                if (tipoExistente == null)
                    throw new KeyNotFoundException($"Tipo de telefone com ID {tipoTelefone.CodigoTipoTelefone} não encontrado.");

                _context.TiposTelefones.Update(tipoExistente);
                await _context.SaveChangesAsync();
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar tipo de telefone: {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var tipo = await _context.TiposTelefones.FindAsync(id);
                if (tipo == null)
                    throw new KeyNotFoundException($"Tipo Telefone com ID {id} não encontrado.");

                tipo.Ativo = false;
                _context.TiposTelefones.Update(tipo);
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
