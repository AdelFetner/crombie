using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EF_Test.Models.Entity;

namespace EF_Test.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Black sneaker", Price = 200 },
                new Product { Id = 2, Name = "White sneaker", Price = 220 }
                );
        }
    }
}
