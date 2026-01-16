namespace FCG.Application.Identidade.DTOs.Auth;

public record AuthResponse(
    string AccessToken,
    Guid RefreshToken,
    DateTime ExpiracaoAccessToken,
    DateTime ExpiracaoRefreshToken,
    UsuarioDto Usuario
);