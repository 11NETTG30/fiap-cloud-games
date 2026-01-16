using FCG.Domain.Identidade.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCG.Infrastructure.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(e => e.Valor)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("Email");
            });

            builder.OwnsOne(u => u.SenhaHash, senhaHash =>
            {
                senhaHash.Property(s => s.Senha)
                    .IsRequired()
                    .HasMaxLength(69)
                    .HasColumnName("SenhaHash");
            });

            builder.Property(u => u.Perfil)
                .IsRequired();

            builder.Property(u => u.Ativo)
                .IsRequired();

            builder.Property(u => u.DataCriacao)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(u => u.DataAtualizacao);
        }
    }
}
