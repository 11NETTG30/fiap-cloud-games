using FCG.Domain.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FCG.API.Controllers;

[ApiController]
[Route("api/conta")]
public class ContaController : ControllerBase
{
    private readonly ILogger<ContaController> _logger;
    
    public ContaController
    (
        ILogger<ContaController> logger
    )
    {
        _logger = logger;
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

    [HttpGet("teste")]
    public void Teste()
    {
        _logger.LogInformation("Testando 123");
        _logger.LogInformation("Testando 456");
        
        throw new ValidationException("Testando 123");
    }
    
}