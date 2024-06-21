using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Infrastructure.Data.Configurations
{
    public class ArticuloConfiguration : IEntityTypeConfiguration<Algoritmo>
    {
        public void Configure(EntityTypeBuilder<Algoritmo> builder)
        {
            builder.HasKey(a => a.Id);

        }
    }

}
