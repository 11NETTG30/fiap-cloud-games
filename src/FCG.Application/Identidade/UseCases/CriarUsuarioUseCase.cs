using FCG.Application.Identidade.DTOs;
using FCG.Domain.Identidade.Entities;
using FCG.Domain.Identidade.Enums;
using FCG.Domain.Identidade.Repositories;
using FCG.Domain.Identidade.Security;
using FCG.Domain.Identidade.ValueObjects;
using FCG.Domain.Shared.Exceptions;

namespace FCG.Application.Identidade.UseCases;

public sealed class CriarUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ISenhaHasher _senhaHasher;

    public CriarUsuarioUseCase
    (
        IUsuarioRepository usuarioRepository,
        ISenhaHasher senhaHasher
    )
    {
        _usuarioRepository = usuarioRepository;
        _senhaHasher = senhaHasher;
    }

    public async Task<Guid> Executar(CriarUsuarioDTO dto)
    {
        Email email = new(dto.Email);

        SenhaTextoPuro senhaTextoPuro = new(dto.Senha, dto.ConfirmacaoSenha);
        SenhaHash senhaHash = _senhaHasher.GerarHash(senhaTextoPuro);

        Usuario usuario = new(dto.Nome, email, senhaHash, PerfilUsuario.Usuario);

        bool emailExiste = await _usuarioRepository.VerificarExistenciaEmail(usuario.Email.Valor);
        
        if (emailExiste)
            throw new ConflictException("Já existe um usuário cadastrado com esse e-mail");

        await _usuarioRepository.Adicionar(usuario);
        await _usuarioRepository.UnitOfWork.Commit();
        
        return usuario.Id;
    }
}