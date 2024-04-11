
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
        public async Task<AddOrderResponse> AddOrder(AddOrderRequest addOrder)
        {
            bool checkUserIdValid = await _authenticationRepository.CheckUserIdValidAsync(addOrder.UserId);
            if (checkUserIdValid)
            {
                bool isCartBelongToUser = await _cartRepository.CheckIsCartBelongToUser(addOrder);
                if (!isCartBelongToUser)
                {
                    return new AddOrderResponse { Status = false, Message = "CartId do not match userId" };
                }
            }

            bool checkCartIdValid = await _cartRepository.CheckCartIdValidAsync(addOrder.CartId);
            if (!checkCartIdValid ) { return new AddOrderResponse {  Status = false, Message = " cartId invalid" };}
            
            

            var result = await _orderRepository.AddOrderAsync(addOrder);
            if (result != null ) 
            {
                var getInfoOrderDetail = await _orderRepository.GetInfoOrderDetailAsync(result.Id);
                if (getInfoOrderDetail != null)
                {
                    bool deleteCartDetailBeLongCartId = await _cartRepository.DeleteCartDetailBeLongCartIdAsync(addOrder.CartId);
                    if (!deleteCartDetailBeLongCartId)
                    {
                        return new AddOrderResponse { Status = false, Message = "Delete cart detail be long cartId false " };
                    }

                    return new AddOrderResponse
                    {
                        Status = true,
                        Message = "AddOrder succes",
                        Order = result,
                        OrderDetails = getInfoOrderDetail
                    };

                
                }
                else
                {
                    return new AddOrderResponse { Status = false, Message = "AddOrder false " };
                }
            }
            else
            {
                 return new AddOrderResponse { Status = false, Message = "AddOrder false " }; 
            }


        }
    }
}
        