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
        public async Task<IActionResult> AddToCart(AddItemToCartRequest addToCart)
        {
            try
            {
                var result = await _cartService.AddToCart(addToCart);
                if(result.Stastus)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }catch (Exception ex) 
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("RemoveItemInCart")]
        public async Task<IActionResult> RemoveItemInCart(Guid cartDetailId)
        {
            try
            {
                var result = await _cartService.RemoveItemInCart(cartDetailId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateCart")]
        public async Task<IActionResult> UpdateCart(UpdateCartRequest updateCart)
        {
            try
            {
                var result = await _cartService.UpdateCart(updateCart);
                if (result.Stastus)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("GetInfoInCart/{id}")]
        public async Task<IActionResult> GetInfoInCart(string id)
        {
            try
            {
                var result = await _cartService.GetInfoInCart(id);
                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
