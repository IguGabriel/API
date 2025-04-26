using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Dtos;
using RO.DevTest.Application.Services;

namespace RO.DevTest.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly ClienteService _service;

    public ClientesController(ClienteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.ObterTodosAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var cliente = await _service.ObterPorIdAsync(id);
        return cliente == null ? NotFound() : Ok(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClienteDto dto)
    {
        await _service.AdicionarAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = dto.Nome }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] ClienteDto dto)
    {
        await _service.AtualizarAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.RemoverAsync(id);
        return NoContent();
    }
}
