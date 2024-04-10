using System.ComponentModel.DataAnnotations;

namespace ShopBabminton_HCM.DTOs.CartDTO
{
    public class AddItemToCartRequest
    { 
        [Required]
        public Guid CartId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
