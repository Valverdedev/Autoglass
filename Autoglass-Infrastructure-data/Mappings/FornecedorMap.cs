using Autoglass_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autoglass_Infrastructure_data.Mappings
{
    internal class FornecedorMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Descricao).IsRequired().HasMaxLength(200);

           
        }
    }
}
