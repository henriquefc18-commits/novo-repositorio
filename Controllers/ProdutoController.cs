using Microsoft.AspNetCore.Mvc;
using produtoapi2.Interfaces;
using produtoapi2.Models;

namespace produtoapi2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{

    private readonly IProdutoService _produtoService;
    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpPost]
    public IActionResult Criar([FromBody] Produto produto)
    {
        if(produto == null)
        {
            return BadRequest("Objeto inválido.");
        }

        try
        {
            _produtoService.Criar(produto);
            return CreatedAtAction(nameof(BuscarPorId), new { id = produto.Id }, produto);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult Listar()
    {
        var produtos = _produtoService.Listar();
        return Ok(produtos);
    }

    [HttpGet("{id:int}")]
    public IActionResult BuscarPorId(int id)
    {
        var produto = _produtoService.BuscarPorId(id);
        if(produto == null)
        {
            return NotFound();
        }
        return Ok(produto);
    }

    [HttpPut("{id:int}")]
    public IActionResult Atualizar(int id, [FromBody] Produto produto)
    {
        try
        {
            if (produto == null || produto.Id != id)
            {
                return BadRequest("Objeto inválido.");
            }

            var existe = _produtoService.BuscarPorId(id);
            if(existe == null)
            {
                return NotFound();
            }

            _produtoService.Atualizar(produto);
            return NoContent();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult Deletar(int id)
    {
        try
        {
            var produto = _produtoService.BuscarPorId(id);
            if(produto == null)
            {
                return NotFound();
            }
            _produtoService.Deletar(id);
            return NoContent();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
