namespace FCG.Application.Identidade.DTOs;

public record CriarUsuarioDTO
{
    public string Nome { get; init; }
    public string Email { get; init; }
    public string Senha { get; init; }
    public string ConfirmacaoSenha { get; init; }
}