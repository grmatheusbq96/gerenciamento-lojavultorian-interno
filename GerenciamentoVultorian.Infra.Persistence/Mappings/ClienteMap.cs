using GerenciamentoVultorian.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoVultorian.Infra.Persistence.Mappings;

public class ClienteMap : IEntityTypeConfiguration<ClienteModel>
{
    public void Configure(EntityTypeBuilder<ClienteModel> builder)
    {
        builder.ToTable("Cliente");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.DataCadastro).HasColumnName("DataCadastro").HasColumnType("date");
        builder.Property(c => c.DataAlteracao).HasColumnName("DataAlteracao").HasColumnType("date");
        builder.Property(c => c.Nome).HasColumnName("Nome").HasColumnType("varchar");
        builder.Property(c => c.Documento).HasColumnName("Documento").HasColumnType("varchar");
        builder.Property(c => c.Endereco).HasColumnName("Endereco").HasColumnType("varchar");
        builder.Property(c => c.Celular).HasColumnName("Celular").HasColumnType("varchar");
        builder.Property(c => c.Email).HasColumnName("Email").HasColumnType("varchar");
    }
}