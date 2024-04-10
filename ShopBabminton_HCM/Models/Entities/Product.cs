using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBabminton_HCM.Models.Entities
{
    [Table("Products")]
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }   
        public Guid CategoryId { get; set; }
        public int Status { get; set; }

        public Category Category { get; set; }

        public virtual ICollection<CartDetail> CartDetail { get; set; }
       public virtual ICollection<OrderDetail> OrderDetail { get; set; }    
    }
}
