using Microsoft.AspNetCore.Mvc;

namespace produtoapi2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    [HttpGet("Get")]
    public async Task<IActionResult> Get()
    {
        return Ok("API de Produtos está funcionando!");
    }
}
