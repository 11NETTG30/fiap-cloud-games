using FCG.Domain.Identidade.Enums;
using FCG.Domain.Identidade.ValueObjects;
using FCG.Domain.Shared.Abstractions;
using FCG.Domain.Shared.Exceptions;

namespace FCG.Domain.Identidade.Entities;

public sealed class Usuario : Entity, IAggregateRoot
{
    public string Nome { get; private set; }
    public Email Email { get; private set; }
    public SenhaHash SenhaHash { get; private set; }
    public PerfilUsuario Perfil { get; private set; }
    public bool Ativo { get; private set; }
    public DateTime DataCriacao { get; }
    public DateTime? DataAtualizacao { get; }
    
    public Usuario
    (
        string nome,
        Email email,
        SenhaHash senhaHash,
        PerfilUsuario perfil
    )
    {
        SetNome(nome);
        SetEmail(email);
        SetSenhaHash(senhaHash);
        SetPerfil(perfil);
        SetAtivo(true);
    }
    
    // EF Core
    private Usuario(){}

    public void SetNome(string nome)
    {
        if (string.IsNullOrEmpty(nome))
            throw new DomainException("Nome não pode ser vazio ou nulo");
        
        if (nome.Length is < 2 or > 100)
            throw new DomainException("Nome deve ter entre 2 e 100 caracteres");
        
        Nome =  nome.Trim();
    }
    
    public void SetEmail(Email email) =>
        Email = email ?? throw new DomainException("E-mail é obrigatório");
    
    public void SetSenhaHash(SenhaHash senhaHash) =>
        SenhaHash = senhaHash ?? throw new DomainException("Senha é obrigatória");

    public void SetPerfil(PerfilUsuario perfil) =>
        Perfil = perfil;

    public void SetAtivo(bool ativo) =>
        Ativo = ativo;
    
    public override string ToString() =>
        $"{Nome} - {Email} - {Id}";

}