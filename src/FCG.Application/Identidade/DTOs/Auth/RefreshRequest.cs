namespace FCG.Application.Identidade.DTOs.Auth;

public record RefreshRequest(
    Guid RefreshToken
);