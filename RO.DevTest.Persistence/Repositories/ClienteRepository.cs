using Microsoft.EntityFrameworkCore;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Domain.Interfaces;

namespace RO.DevTest.Persistence.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly DefaultContext _context;

    public ClienteRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cliente>> ObterTodosAsync()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Cliente> ObterPorIdAsync(Guid id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task AdicionarAsync(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(Guid id)
    {
        var cliente = await ObterPorIdAsync(id);
        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
