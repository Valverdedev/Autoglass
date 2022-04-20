using Autoglass_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autoglass_Infrastructure_data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Descricao).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Situacao);
            builder.Property(e => e.DataFabricacao).IsRequired();
            builder.Property(e => e.DataValidade);
            builder.Property(e => e.DataFabricacao);
            builder.Property(e => e.DescricaoFornecedor);
            builder.Property(e => e.CnpjFornecedor).HasMaxLength(14);
        }
    }
}
