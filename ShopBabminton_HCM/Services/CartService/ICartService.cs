using ShopBabminton_HCM.DTOs.CartDTO;

namespace ShopBabminton_HCM.Services.CartService
{
    public interface ICartService
    {
        public Task<AddItemToCartResponse> AddToCart(AddItemToCartRequest model);
        public Task<bool> RemoveItemInCart(Guid models);
        public Task<UpdateCartResponse> UpdateCart(UpdateCartRequest models);
        public Task<GetInfoInCartDetailResponse> GetInfoInCart(Guid cartId);
    }
}
