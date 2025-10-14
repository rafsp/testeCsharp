using CandidatosBusiness;
using CandidatosModel;
using Microsoft.AspNetCore.Mvc;

namespace CandidatosApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CandidatosController
(
    ICandidatoService candidatoService
) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var candidatos = candidatoService.ListarTodos();
        return candidatos.Count == 0 ? NoContent() : Ok(candidatos);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var candidato = candidatoService.ObterPorId(id);
        return candidato == null ? NotFound() : Ok(candidato);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CandidatoModel candidato)
    {
        if (string.IsNullOrWhiteSpace(candidato.Nome))
            return BadRequest("Nome é obrigatório.");
        var criado = candidatoService.Criar(candidato);
        return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
    }

    [HttpPut]
    public IActionResult Put([FromBody] CandidatoModel candidato)
    {
        if (candidato == null)
            return BadRequest("Dados inconsistentes.");
        return candidatoService.Atualizar(candidato) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        return candidatoService.Remover(id) ? NoContent() : NotFound();
    }
}