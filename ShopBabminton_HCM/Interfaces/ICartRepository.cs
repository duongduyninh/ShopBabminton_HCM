using ShopBabminton_HCM.DTOs.CartDTO;

namespace ShopBabminton_HCM.Interfaces
{
    public interface ICartRepository
    {
        public Task<bool> AddToCartAsync(AddToCartDTO model);
        public Task<bool> CheckCartIdValidAsync(Guid model);
        public Task<bool> CreateCartAsync(string model);
    }
}
