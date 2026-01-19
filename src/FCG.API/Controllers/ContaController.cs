using FCG.Application.Identidade.DTOs;
using FCG.Application.Identidade.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCG.API.Controllers;

[ApiController]
[Route("api/conta")]
[Authorize]
public sealed class ContaController : ControllerBase
{
    private readonly ObterContaUseCase _obterContaUseCase;
    
    public ContaController
    (
        ObterContaUseCase obterContaUseCase
    )
    {
        _obterContaUseCase = obterContaUseCase;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<string>> Obter()
    {
        UsuarioDto? usuario = await _obterContaUseCase.Executar();
        
        return Ok(usuario);
    }
    
    [HttpPatch("senha")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<string>> AlterarSenha()
    {
        await Task.Delay(200);
        
        return NoContent();
    }
    
}