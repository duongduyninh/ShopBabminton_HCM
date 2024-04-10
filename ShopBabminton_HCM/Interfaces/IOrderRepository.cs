namespace ShopBabminton_HCM.Interfaces
{
    public interface IOrderRepository
    {
        public Task<bool> AddOrderAsync(string? userId , Guid cartId);
        public Task<bool> AddOrderDetailsAsync(Guid model);
    }
}