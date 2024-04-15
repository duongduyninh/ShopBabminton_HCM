using ShopBabminton_HCM.Models.Entities;

namespace ShopBabminton_HCM.DTOs.ProductDTO
{
    public class GetAllProductRequest
    {
        public Guid? CategoryId { get; set; }
        public double? PriceFrom { get; set; }
        public double? PriceTo { get; set; }
    }
}
