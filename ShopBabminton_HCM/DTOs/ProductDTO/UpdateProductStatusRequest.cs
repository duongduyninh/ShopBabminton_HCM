using System.ComponentModel.DataAnnotations;

namespace ShopBabminton_HCM.DTOs.ProductDTO
{
    public class UpdateProductStatusRequest
    {
        [Required]
        public Guid productId {  get; set; }
        [Required, Range(0,1)]
        public int Status { get; set; }
    }
}
