using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopBabminton_HCM.Models.Entities;

namespace ShopBabminton_HCM.Models.EntityConfigurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Order)
                .WithMany(u=>u.OrderDetail)
                .HasForeignKey(x => x.OrderId)
                .IsRequired();

            builder.HasOne(x=>x.Product)
                    .WithMany(k=>k.OrderDetail)
                    .HasForeignKey(x => x.ProductId)
                    .IsRequired();
        }
    }
}
