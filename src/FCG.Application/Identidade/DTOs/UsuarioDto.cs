namespace FCG.Application.Identidade.DTOs;

public record UsuarioDto(
    Guid Id,
    string Nome,
    string Email,
    byte Perfil
);