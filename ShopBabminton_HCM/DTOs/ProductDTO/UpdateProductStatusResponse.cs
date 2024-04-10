namespace ShopBabminton_HCM.DTOs.ProductDTO
{
    public class UpdateProductStatusResponse
    {
        public bool Status { get; set; }
        public string? Message { get; set; } 
        public Guid ProductId { get; set; } 
    }
}
