using System.ComponentModel.DataAnnotations;

namespace ShopBabminton_HCM.DTOs.ProductDTO
{
    public class AddProductRequest
    {
        [Required]
        public string ProductName { get; set; }
        public string? Description { get; set; }
        [Required, Range(1 , double.MaxValue)]
        public double Price { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
    }
}