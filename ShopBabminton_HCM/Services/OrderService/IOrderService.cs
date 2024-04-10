using ShopBabminton_HCM.DTOs.OrderDTO;

namespace ShopBabminton_HCM.Services.OrderService
{
    public interface IOrderService
    {
        public Task<OrderResultDTO> AddOrder(string? userId,Guid cartId);
    }
}
