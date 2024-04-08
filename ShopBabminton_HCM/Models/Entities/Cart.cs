using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBabminton_HCM.Models.Entities
{
    [Table("Carts")]
    public class Cart
    {
        public Guid Id { get; set; }
        public String UserId { get; set; }

        public AppUser User { get; set; }

        public ICollection<CartDetail> CartDetail { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
