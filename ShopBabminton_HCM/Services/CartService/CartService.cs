using ShopBabminton_HCM.DTOs.CartDTO;
using ShopBabminton_HCM.Interfaces;
using ShopBabminton_HCM.Models.Entities;
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
        public async Task<AddItemToCartResponse> AddToCart(AddItemToCartRequest addToCart)
        {

            bool CheckProductIdValid = await _productRepository.CheckProductIdValidAsync(addToCart.ProductId);
            if (!CheckProductIdValid) { return new AddItemToCartResponse { Stastus = false, Message = "Product inValid" }; }

            bool CheckCartIdValid = await _cartRepository.CheckCartIdValidAsync(addToCart.CartId);
            if (!CheckCartIdValid) { return new AddItemToCartResponse { Stastus = false, Message = "Cart inValid" }; }

            var result = await _cartRepository.AddToCartAsync(addToCart);
            if (result == null)
            { return new AddItemToCartResponse { Stastus = false, Message = "AddToCart false" }; }

            return new AddItemToCartResponse { Stastus = true, Message = "AddToCart success", Product = result };
        }

        public async Task<bool> RemoveItemInCart(Guid cartDetailId)
        {
            bool checkCartDetailId = await _cartRepository.CheckCartDetailIdValIdAsync(cartDetailId);
            if (!checkCartDetailId) { return false; }

            return await _cartRepository.RemoveItemInCartAsync(cartDetailId);
        }

        public async Task<UpdateCartResponse> UpdateCart(UpdateCartRequest updateCartDTO)
        {
           bool checkCartDetailId = await _cartRepository.CheckCartDetailIdValIdAsync(updateCartDTO.CartDetailId);
           if (!checkCartDetailId) { return new UpdateCartResponse { Stastus = false , Message = "CartDetailId inValid"}; }

           var result = await _cartRepository.UpdateCartDetailAsync(updateCartDTO);
           if (result == null)
           {
               return new UpdateCartResponse { Stastus = false, Message = "UpdateCart false" };
           }

            return new UpdateCartResponse { Stastus = true, Message = "UpdateCart Success" ,CartDetail = result };
        }

        public async Task<GetInfoInCartDetailResponse> GetInfoInCart(Guid cartId)
        {

           var result = await _cartRepository.GetInfoInCartAsync(cartId);
            if (result == null)
            {
                return new GetInfoInCartDetailResponse { Status = false, Message = "" };
            }

            return new GetInfoInCartDetailResponse { Status = true, Message = "Get Info CartDetail success" , cartDetail = result };
        }

    }
}
