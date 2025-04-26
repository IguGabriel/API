using RO.DevTest.Application.Dtos;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Domain.Interfaces;

namespace RO.DevTest.Application.Services;

public class ClienteService
{
    private readonly IClienteRepository _repository;

    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Cliente>> ObterTodosAsync()
    {
        return await _repository.ObterTodosAsync();
    }

    public async Task<Cliente> ObterPorIdAsync(Guid id)
    {
        return await _repository.ObterPorIdAsync(id);
    }

    public async Task AdicionarAsync(ClienteDto dto)
    {
        var cliente = new Cliente
        {
            Id = Guid.NewGuid(),
            Nome = dto.Nome,
            Email = dto.Email,
            Telefone = dto.Telefone
        };

        await _repository.AdicionarAsync(cliente);
    }

    public async Task AtualizarAsync(Guid id, ClienteDto dto)
    {
        var cliente = await _repository.ObterPorIdAsync(id);

        if (cliente == null) throw new Exception("Cliente não encontrado");

        cliente.Nome = dto.Nome;
        cliente.Email = dto.Email;
        cliente.Telefone = dto.Telefone;

        await _repository.AtualizarAsync(cliente);
    }

    public async Task RemoverAsync(Guid id)
    {
        await _repository.RemoverAsync(id);
    }
}
