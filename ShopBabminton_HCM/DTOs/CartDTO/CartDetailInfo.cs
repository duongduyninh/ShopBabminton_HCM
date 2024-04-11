using System.ComponentModel.DataAnnotations;

namespace ShopBabminton_HCM.DTOs.CartDTO
{
    public class CartDetailInfo
    {
        [Required]
        public Guid CartId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}