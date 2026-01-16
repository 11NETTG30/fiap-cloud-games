using FCG.Application.Identidade.DTOs.Auth;
using FCG.Application.Identidade.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCG.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly LoginUseCase _loginUseCase;
    private readonly RefreshTokenUseCase _refreshTokenUseCase;
    private readonly LogoutUseCase _logoutUseCase;
    
    public AuthController
    (
        ILogger<AuthController> logger,
        LoginUseCase loginUseCase,
        RefreshTokenUseCase refreshTokenUseCase,
        LogoutUseCase logoutUseCase
    )
    {
        _logger = logger;
        _loginUseCase = loginUseCase;
        _refreshTokenUseCase = refreshTokenUseCase;
        _logoutUseCase = logoutUseCase;
    }

    [HttpPost("registrar")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> Registrar()
    {
        await Task.Delay(200);
        
        // TODO: Analisar se já retorna o JWT ou somente a uri do login no header
        return Created();
    }
    
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequest request)
    {
        AuthResponse response = await _loginUseCase.Executar(request);
        
        return Ok(response);
    }
    
    [HttpPost("refresh")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<string>> Refresh([FromBody] RefreshRequest request)
    {
        AuthResponse response = await _refreshTokenUseCase.Executar(request);
        
        return Ok(response);
    }
    
    [HttpPost("logout")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Logout([FromBody] LogoutRequest request)
    {
        await _logoutUseCase.Executar(request);
        
        return NoContent();
    }
    
}