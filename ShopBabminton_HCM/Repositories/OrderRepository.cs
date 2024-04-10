using Microsoft.EntityFrameworkCore;
using ShopBabminton_HCM.Data;
using ShopBabminton_HCM.Interfaces;
using ShopBabminton_HCM.Models.Entities;
using ShopBabminton_HCM.Helpers;

namespace ShopBabminton_HCM.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IProductRepository _productRepository;
        private readonly DbContextStoreBabmintion _context;

        public OrderRepository(DbContextStoreBabmintion context
                                , IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _context = context;
        }
        public async Task<bool> AddOrderAsync(string? userId, Guid cartId)
        {
         
            var newOrder = new Order
            {
                UserId = userId,
                CartId = cartId,
                Status = (int)Enums.OrderStatus.pendingConfirmation,
                CreatedTime = DateTime.UtcNow,
            };
            _context.Orders.Add(newOrder);
            Guid orderId = newOrder.Id;
            
            var checkNewOrder = await _context.SaveChangesAsync();
            if (checkNewOrder > 0 ) 
            {
                bool addOrderDetail = await AddOrderDetailsAsync(orderId);
                if (!addOrderDetail) { return false; }
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
        public async Task<bool> AddOrderDetailsAsync(Guid orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
            if (order == null) { return false; }
            
            var cartId = order.CartId;

            var getListCartDetail = await (from cartDetail in _context.CartDetails
                                           where cartDetail.CartId == cartId
                                           select cartDetail).ToListAsync();

            int countForeach = 0;
            foreach ( var cartDetailTMP in getListCartDetail ) 
            {
                if (cartDetailTMP.Quantity == 0 ) { continue; }

                var productId = cartDetailTMP.ProductId;
                var infProduct = await _productRepository.GetProductAsync(productId);
                if (infProduct == null) { continue;}

                var newOrderDetail = new OrderDetail
                {
                    OrderId = orderId,
                    ProductId = productId,
                    ProductName = infProduct.ProductName,
                    Price = infProduct.Price,
                    Quantity = cartDetailTMP.Quantity,
                    CreatedTime = DateTime.UtcNow,  
                };
                _context.OrderDetails.Add(newOrderDetail);
                countForeach++;
            }
            if (countForeach == 0) { return false; }

            return true;
        }
    }
}
