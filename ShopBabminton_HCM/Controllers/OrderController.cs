using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBabminton_HCM.DTOs.OrderDTO;
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
        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder(AddOrderRequest addOrder)
        {
            try
            {
                var result = await _orderService.AddOrder(addOrder);
                if (result.Status)
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
    }   
}
