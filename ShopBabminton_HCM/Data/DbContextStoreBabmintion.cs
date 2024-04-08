using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopBabminton_HCM.Models.Entities;
using ShopBabminton_HCM.Models.EntityConfigurations;

namespace ShopBabminton_HCM.Data
{
    public class DbContextStoreBabmintion :IdentityDbContext<AppUser>
    {
        public DbContextStoreBabmintion(DbContextOptions<DbContextStoreBabmintion> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RefreshTokenConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CartConfiguration()); 
            builder.ApplyConfiguration(new CartDetailConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderDetailConfiguration());


            foreach (var EntityType in builder.Model.GetEntityTypes())
            {
                var tableName = EntityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    var newName = tableName.Substring(6);
                    EntityType.SetTableName(newName);
                }
            }
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


    }
}
