namespace ShopBabminton_HCM.DTOs.ProductDTO
{
    public class UpdateProductResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public Guid ProductId { get; set; }
        public ProductInfo ProductInfo { get; set; }
    }
}
