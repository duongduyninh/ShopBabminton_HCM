using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBabminton_HCM.Services.OrderService;

namespace ShopBabminton_HCM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("AddOrder/{cartId}")]
        public async Task<IActionResult> AddOrder(string? userId,Guid cartId)
        {
            try
            {
                var result = await _orderService.AddOrder(userId, cartId);
                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }   
}
