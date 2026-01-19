using FCG.Application.Identidade.DTOs;
using FCG.Application.Identidade.UseCases;
using FCG.Infrastructure.Identidade.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCG.API.Controllers;

[ApiController]
[Route("api/usuarios")]
[Authorize(Roles = RoleNames.Admin)]
public class UsuarioController : ControllerBase
{
    private readonly ListarTodosUsuariosUseCase _listarTodosUsuariosUseCase;
    
    public UsuarioController
    (
        ListarTodosUsuariosUseCase listarTodosUsuariosUseCase
    )
    {
        _listarTodosUsuariosUseCase = listarTodosUsuariosUseCase;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<UsuarioDto>>> Listar()
    {
        IEnumerable<UsuarioDto> usuarios = await _listarTodosUsuariosUseCase.Executar();
        
        return Ok(usuarios);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<string>> Obter(Guid id)
    {
        await Task.Delay(100);
        
        return Ok($"Usuário com id '{id}'");
    }

    [HttpPatch("{id:guid}/perfil-usuario")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> AlterarPerfilUsuario()
    {
        await Task.Delay(100);
        
        return NoContent();
    }
    
}