namespace FCG.Application.Identidade.DTOs.Auth;

public record UsuarioDto(
    Guid Id,
    string Nome,
    string Email,
    byte Perfil
);