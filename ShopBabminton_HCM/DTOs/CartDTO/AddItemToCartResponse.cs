using ShopBabminton_HCM.DTOs.ProductDTO;

namespace ShopBabminton_HCM.DTOs.CartDTO
{
    public class AddItemToCartResponse
    {
        public bool Stastus { get; set; }
        public string Message { get; set; }
        public ProductInfoById Product { get; set; }
    }
}
