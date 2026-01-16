namespace FCG.Application.Identidade.DTOs.Auth;

public record LogoutRequest(
    Guid RefreshToken
);