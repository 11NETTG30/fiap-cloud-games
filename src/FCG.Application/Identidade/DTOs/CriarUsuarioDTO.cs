namespace FCG.Application.Identidade.DTOs;

public record CriarUsuarioDTO(
    string Nome,
    string Email,
    string Senha,
    string ConfirmacaoSenha
);