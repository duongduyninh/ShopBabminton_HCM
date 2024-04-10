namespace ShopBabminton_HCM.DTOs.ProductDTO
{
    public class GetProductsByCategoryResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<ProductInfoById> product { get; set; }
    }
}
