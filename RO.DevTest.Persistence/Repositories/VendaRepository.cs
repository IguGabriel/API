using Microsoft.EntityFrameworkCore;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Domain.Interfaces;

namespace RO.DevTest.Persistence.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DefaultContext _context;

        public VendaRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Venda>> ObterTodasAsync()
        {
            return await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Produto)
                .ToListAsync();
        }

        public async Task<Venda> ObterPorIdAsync(Guid id)
        {
            return await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task AdicionarAsync(Venda venda)
        {
            // Anexando o Cliente e o Produto existentes
            _context.Attach(venda.Cliente);
            _context.Attach(venda.Produto);

            await _context.Vendas.AddAsync(venda);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var venda = await ObterPorIdAsync(id);
            if (venda != null)
            {
                _context.Vendas.Remove(venda);
                await _context.SaveChangesAsync();
            }
        }
    }
}
