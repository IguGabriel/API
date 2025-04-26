using RO.DevTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RO.DevTest.Domain.Interfaces
{
    public interface IVendaRepository
    {
        Task<IEnumerable<Venda>> ObterTodasAsync();
        Task<Venda> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(Venda venda);
        Task RemoverAsync(Guid id);
    }
}
