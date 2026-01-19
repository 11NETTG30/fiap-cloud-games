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
    private readonly ObterUsuarioPorIdUseCase _obterUsuarioPorIdUseCase;
    
    public UsuarioController
    (
        ListarTodosUsuariosUseCase listarTodosUsuariosUseCase,
        ObterUsuarioPorIdUseCase obterUsuarioPorIdUseCase
    )
    {
        _listarTodosUsuariosUseCase = listarTodosUsuariosUseCase;
        _obterUsuarioPorIdUseCase = obterUsuarioPorIdUseCase;
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
    public async Task<ActionResult<UsuarioDto>> Obter(Guid id)
    {
        UsuarioDto? usuario = await _obterUsuarioPorIdUseCase.Executar(id);
        
        return Ok(usuario);
    }

    [HttpPatch("{id:guid}/perfil-usuario")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> AlterarPerfilUsuario()
    {
        await Task.Delay(100);
        
        return NoContent();
    }
    
}