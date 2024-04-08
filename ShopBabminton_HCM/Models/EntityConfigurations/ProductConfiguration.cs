using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopBabminton_HCM.Models.Entities;

namespace ShopBabminton_HCM.Models.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(u => u.Category)
                    .WithMany(c=>c.Product)
                    .HasForeignKey(u => u.CategoryId)
                    .IsRequired();
        }
    }
}
