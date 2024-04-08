using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopBabminton_HCM.Models.Entities;

namespace ShopBabminton_HCM.Models.EntityConfigurations
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Cart)
                .WithMany(q => q.CartDetail)
                .HasForeignKey(x => x.CartId)
                 .IsRequired();

            builder.HasOne(x=>x.Product)
                .WithMany(q=>q.CartDetail)
                .HasForeignKey(x => x.ProductId)
                .IsRequired();

        }
    }
}
