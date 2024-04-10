using ShopBabminton_HCM.DTOs.ProductDTO;
using ShopBabminton_HCM.Models.Entities;

namespace ShopBabminton_HCM.DTOs.CartDTO
{
    public class UpdateCartResponse
    {
        public bool Stastus { get; set; }
        public string Message { get; set; }
        public CartDetailInfo CartDetail { get; set; }
    }
}
