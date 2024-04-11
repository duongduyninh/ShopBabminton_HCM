using ShopBabminton_HCM.DTOs.OrderDTO;

namespace ShopBabminton_HCM.Services.OrderService
{
    public interface IOrderService
    {
        public Task<AddOrderResponse> AddOrder(AddOrderRequest models);
    }
}
