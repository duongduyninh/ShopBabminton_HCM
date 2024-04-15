namespace ShopBabminton_HCM.DTOs.ProductDTO
{
    public class GetAllProductResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; } 
        public List<ProductInfoById> ProductInfo { get; set; }
    }
}
