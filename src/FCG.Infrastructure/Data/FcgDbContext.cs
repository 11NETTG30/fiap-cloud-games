using FCG.Domain.Identidade.Entities;
using FCG.Domain.Shared.UoW;
using Microsoft.EntityFrameworkCore;

namespace FCG.Infrastructure.Data
{
    public class FcgDbContext : DbContext, IUnitOfWork
    {
        public FcgDbContext(DbContextOptions<FcgDbContext> options) : base(options)
        {
        }

        #region tabelas
        public DbSet<Usuario> Usuarios { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FcgDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}
