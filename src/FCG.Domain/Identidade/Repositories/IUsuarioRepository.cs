using FCG.Domain.Identidade.Entities;
using FCG.Domain.Shared.Abstractions;

namespace FCG.Domain.Identidade.Repositories;

public interface IUsuarioRepository : IRepository<Usuario>
{
    Task<Usuario> ObterPorId(Guid id);
    Task Adicionar(Usuario usuario);
    Task Atualizar(Usuario usuario);
    Task<bool> VerificarExistenciaEmail(string email);
}