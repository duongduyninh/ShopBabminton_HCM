using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopBabminton_HCM.Data;
using ShopBabminton_HCM.DTOs.CartDTO;
using ShopBabminton_HCM.DTOs.ProductDTO;
using ShopBabminton_HCM.Interfaces;
using ShopBabminton_HCM.Models.Entities;

namespace ShopBabminton_HCM.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly DbContextStoreBabmintion _context;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public CartRepository(DbContextStoreBabmintion context 
                                , IMapper mapper
                                , IProductRepository productRepository)
        {
            _context = context;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductInfoById> AddToCartAsync(AddItemToCartRequest addToCart)
        {
            try
            {
                var addItemToCart = _mapper.Map<CartDetail>(addToCart);
                addItemToCart.Created = DateTime.UtcNow;

                await _context.CartDetails.AddAsync(addItemToCart);
                await _context.SaveChangesAsync();

                var getProductInfoById = await _productRepository.GetProductInfoByIdAsync(addToCart.ProductId);

                return _mapper.Map<ProductInfoById>(getProductInfoById);
            }
            catch (Exception ex) 
            {
               return null;
            }
        }

        public async Task<bool> CreateCartAsync(string userId)
        {
            try
            {
                var infoCart = new Cart
                {
                    UserId = userId,
                };
                var createCart = await _context.Carts.AddAsync(infoCart);
                _context.SaveChanges();
                return true;

            }catch (Exception ex) { return false; }
        }

        public async Task<bool> RemoveItemInCartAsync(Guid cartDetailId)
        {
            var removeItem = await _context.CartDetails.FirstOrDefaultAsync(x => x.Id == cartDetailId);
            if (removeItem != null)
            {
                _context.CartDetails.Remove(removeItem);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<GetInfoInCartResultDTO>> GetInfoInCartAsync(string userId)
        {
            var getCartId = await _context.Carts.FirstOrDefaultAsync(x => x.UserId == userId);
            Guid cartId = getCartId.Id;

            var getListCartDetail = await (from cartDetail in _context.CartDetails
                                           where cartDetail.CartId == cartId
                                           select new GetInfoInCartResultDTO
                                           {
                                               UserId = userId,
                                               Id = cartDetail.Id,
                                               CartId = cartDetail.CartId,
                                               ProductId = cartDetail.ProductId,
                                               Created = cartDetail.Created,
                                               Updated = cartDetail.Updated,
                                               Quantity = cartDetail.Quantity,

                                           }).ToListAsync();
            return getListCartDetail;
        }

        public async Task<bool> CheckCartDetailIdValIdAsync(Guid cartDetailId)
        {
            return await _context.CartDetails.AnyAsync(x => x.Id == cartDetailId);
        }

        public async Task<bool> CheckCartIdValidAsync(Guid cartId)
        {
            return await _context.Carts.AnyAsync(x => x.Id == cartId);
        }

        public async Task<bool> CheckIfUserHasCartAsync(string userId)
        {
            return await _context.Carts.AnyAsync(x => x.UserId == userId);
        }

        public async Task<CartDetailInfo> UpdateCartDetailAsync(UpdateCartRequest updateCart)
        {
            var updateCartDetail = await _context.CartDetails.FirstOrDefaultAsync(x => x.Id == updateCart.CartDetailId);
            if (updateCartDetail != null)
            {
                updateCart.Updated = DateTime.UtcNow;
                _mapper.Map(updateCart, updateCartDetail);
                await _context.SaveChangesAsync();
                return _mapper.Map<CartDetailInfo>(updateCart);
            }
            else
            {
                return null;
            }
        }
    }   
    
}
