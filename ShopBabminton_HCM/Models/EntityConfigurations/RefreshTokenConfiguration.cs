using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopBabminton_HCM.Models.Entities;

namespace ShopBabminton_HCM.Models.EntityConfigurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(r => r.User)
                .WithOne()
                .HasForeignKey<RefreshToken>(x => x.UserId);
        }
    }
}
