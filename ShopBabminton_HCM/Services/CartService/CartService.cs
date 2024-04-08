using ShopBabminton_HCM.DTOs.CartDTO;
using ShopBabminton_HCM.Interfaces;
using ShopBabminton_HCM.Repositories;

namespace ShopBabminton_HCM.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;

        public CartService(IProductRepository productRepository
                            ,ICartRepository cartRepository)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }
        public async Task<bool> AddToCart(AddToCartDTO addToCart)
        {
            try
            {
                bool CheckProductIdExist = await _productRepository.CheckProductIdExistAsync(addToCart.ProductId);
                if (!CheckProductIdExist)
                {
                    return false;
                }

                return await _cartRepository.AddToCartAsync(addToCart);

            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
