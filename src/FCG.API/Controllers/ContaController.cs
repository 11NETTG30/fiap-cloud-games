using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCG.API.Controllers;

[ApiController]
[Route("api/conta")]
[Authorize]
public sealed class ContaController : ControllerBase
{
    public ContaController
    (
        
    )
    {
        
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<string>> Obter()
    {
        await Task.Delay(200);
        
        return Ok("Usuário");
    }
    
    [HttpPatch("senha")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<string>> AlterarSenha()
    {
        await Task.Delay(200);
        
        return NoContent();
    }
    
}