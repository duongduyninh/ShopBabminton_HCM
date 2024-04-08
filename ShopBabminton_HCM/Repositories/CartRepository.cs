using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopBabminton_HCM.Data;
using ShopBabminton_HCM.DTOs.CartDTO;
using ShopBabminton_HCM.Interfaces;
using ShopBabminton_HCM.Models.Entities;

namespace ShopBabminton_HCM.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly DbContextStoreBabmintion _context;
        private readonly IMapper _mapper;

        public CartRepository(DbContextStoreBabmintion context 
                                , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddToCartAsync(AddToCartDTO addToCart)
        {
            try
            {
                bool checkCartIdValid = await CheckCartIdValidAsync(addToCart.CartId);
                if (!checkCartIdValid) { return false; }

                var addItemToCart = _mapper.Map<CartDetail>(addToCart);
                addItemToCart.Created = DateTime.UtcNow;

                await _context.CartDetails.AddAsync(addItemToCart);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
               return false;
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

        public async Task<bool> CheckCartIdValidAsync(Guid cartId)
        {
            return await _context.CartDetails.AnyAsync(x=>x.CartId == cartId);
        }

    }
}
