using ShopBabminton_HCM.DTOs.CartDTO;

namespace ShopBabminton_HCM.Services.CartService
{
    public interface ICartService
    {
        public Task<bool> AddToCart(AddToCartDTO model);
    }
}
