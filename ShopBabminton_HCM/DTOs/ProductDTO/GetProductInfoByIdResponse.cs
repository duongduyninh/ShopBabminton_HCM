namespace ShopBabminton_HCM.DTOs.ProductDTO
{
    public class GetProductInfoByIdResponse
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public Guid ProductId { get; set; }
        public ProductInfoById Product { get; set; } 
    }
}
