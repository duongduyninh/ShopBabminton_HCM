using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBabminton_HCM.Models.Entities
{
    [Table("CartDetails")]
    public class CartDetail
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public Cart Cart { get; set; }

    }
}
