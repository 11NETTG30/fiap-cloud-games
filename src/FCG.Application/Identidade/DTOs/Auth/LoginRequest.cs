namespace FCG.Application.Identidade.DTOs.Auth;

public record LoginRequest (
    string Email,
    string Senha
);