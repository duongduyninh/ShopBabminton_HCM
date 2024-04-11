using ShopBabminton_HCM.DTOs.CartDTO;
using ShopBabminton_HCM.DTOs.OrderDTO;
using ShopBabminton_HCM.DTOs.ProductDTO;

namespace ShopBabminton_HCM.Interfaces
{
    public interface ICartRepository
    {
        public Task<ProductInfoById> AddToCartAsync(AddItemToCartRequest model);
        public Task<bool> CheckCartIdValidAsync(Guid model);
        public Task<bool> CreateCartAsync(string model);
        public Task<bool> RemoveItemInCartAsync(Guid models);
        public Task<bool> CheckCartDetailIdValIdAsync(Guid model);
        public Task<CartDetailInfo> UpdateCartDetailAsync(UpdateCartRequest model);
        public Task<bool> CheckIfUserHasCartAsync(string model);
        public Task<List<CartDetailInfo>> GetInfoInCartAsync(string model);
        public Task<bool> CheckIsCartBelongToUser(AddOrderRequest models);
        public Task<bool> DeleteCartDetailBeLongCartIdAsync(Guid cartId);
    }
}
