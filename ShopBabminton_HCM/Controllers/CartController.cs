using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBabminton_HCM.DTOs.CartDTO;
using ShopBabminton_HCM.Services.CartService;

namespace ShopBabminton_HCM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart(AddToCartDTO addToCart)
        {
            try
            {
                var result = await _cartService.AddToCart(addToCart);
                return Ok(result);
            }catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
