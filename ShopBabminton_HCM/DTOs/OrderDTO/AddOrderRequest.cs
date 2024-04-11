using System.ComponentModel.DataAnnotations;

namespace ShopBabminton_HCM.DTOs.OrderDTO
{
    public class AddOrderRequest
    {
        [Required]
        public Guid CartId { get; set; }
        public string? UserId { get; set; }
    }
}
