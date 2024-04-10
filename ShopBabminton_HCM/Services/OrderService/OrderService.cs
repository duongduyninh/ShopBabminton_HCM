
using ShopBabminton_HCM.DTOs.OrderDTO;
using ShopBabminton_HCM.Interfaces;
using ShopBabminton_HCM.Repositories;

namespace ShopBabminton_HCM.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IAuthenticationRepository _authenticationRepository;

        public OrderService(IOrderRepository orderRepository
                            , ICartRepository cartRepository
                            , IAuthenticationRepository authenticationRepository)
        {
            _orderRepository = orderRepository;
            _cartRepository =cartRepository;
            _authenticationRepository = authenticationRepository;
        }
        public async Task<OrderResultDTO> AddOrder(string? userId, Guid cartId)
        {
            bool checkCartIdValid = await _cartRepository.CheckCartIdValidAsync(cartId);
            if (!checkCartIdValid ) { return new OrderResultDTO { 
                Status = false,
                UserId = userId,
                Operation = "AddOrder" ,
                Message = " cartId invalid" };
            }
            
            bool result = await _orderRepository.AddOrderAsync(userId, cartId);
            if (result) { return new OrderResultDTO { Status = true, UserId = userId, Operation = "AddOrder", Message = " " }; }

            return new OrderResultDTO { Status = false ,UserId = userId, Operation = "AddOrder" }; ;
        }
    }
}
        