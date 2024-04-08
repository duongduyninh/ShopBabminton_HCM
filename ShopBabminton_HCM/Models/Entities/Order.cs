using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBabminton_HCM.Models.Entities
{
    [Table("Orders")]
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid CartId { get; set; }
        public int Status { get; set; } 
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

        public AppUser User { get; set; }
        public Cart Cart { get; set; }

        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
