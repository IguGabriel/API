using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Domain.Interfaces;

namespace RO.DevTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IVendaRepository _repository;

        public VendasController(IVendaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> Get()
        {
            return Ok(await _repository.ObterTodasAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> Get(Guid id)
        {
            var venda = await _repository.ObterPorIdAsync(id);
            if (venda == null)
                return NotFound();
            return Ok(venda);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Venda venda)
        {
            
            venda.Id = Guid.NewGuid();
            await _repository.AdicionarAsync(venda);
            return CreatedAtAction(nameof(Get), new { id = venda.Id }, venda);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _repository.RemoverAsync(id);
            return NoContent();
        }
    }
}
