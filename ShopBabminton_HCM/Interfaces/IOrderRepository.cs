using ShopBabminton_HCM.DTOs.OrderDTO;

namespace ShopBabminton_HCM.Interfaces
{
    public interface IOrderRepository
    {
        public Task<InfoOrder> AddOrderAsync(AddOrderRequest models);
        public Task<bool> AddOrderDetailsAsync(Guid model);
        public Task<List<InfoOrderDetail>> GetInfoOrderDetailAsync(Guid orderId);
        public Task<InfoOrder> GetInfoOrderAsync(Guid orderId);
    }
}