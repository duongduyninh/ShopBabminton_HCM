using System.ComponentModel.DataAnnotations;

namespace ShopBabminton_HCM.DTOs.CartDTO
{
    public class UpdateCartRequest
    {
        [Required]
        public Guid CartDetailId { get; set; }
        public DateTime? Updated { get; set; }
        [Required, Range(0 , int.MaxValue)]
        public int Quantity { get; set; }
    }
}
