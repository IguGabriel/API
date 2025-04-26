using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Domain.Interfaces;

namespace RO.DevTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _repository;

        public ProdutosController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
        {
            return Ok(await _repository.ObterTodosAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> Get(Guid id)
        {
            var produto = await _repository.ObterPorIdAsync(id);
            if (produto == null)
                return NotFound();
            return Ok(produto);
        }

       [HttpPost]
        public async Task<ActionResult> Post([FromBody] Produto produto)
        {
            produto.Id = Guid.NewGuid(); // <-- Adicione essa linha
            await _repository.AdicionarAsync(produto);
            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
                return BadRequest();

            await _repository.AtualizarAsync(produto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _repository.RemoverAsync(id);
            return NoContent();
        }
    }
}
