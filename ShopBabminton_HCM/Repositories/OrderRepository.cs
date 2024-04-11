using Microsoft.EntityFrameworkCore;
using ShopBabminton_HCM.Data;
using ShopBabminton_HCM.Interfaces;
using ShopBabminton_HCM.Models.Entities;
using ShopBabminton_HCM.Helpers;
using ShopBabminton_HCM.DTOs.OrderDTO;

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
        public async Task<InfoOrder> AddOrderAsync(AddOrderRequest addOrder)
        {
         
            var newOrder = new Order
            {
                UserId = addOrder.UserId,
                CartId = addOrder.CartId,
                Status = (int)Enums.OrderStatus.pendingConfirmation,
                CreatedTime = DateTime.UtcNow,
            };
            _context.Orders.Add(newOrder);
            Guid orderId = newOrder.Id;
            
            var checkNewOrder = await _context.SaveChangesAsync();
            if (checkNewOrder > 0 ) 
            {
                bool addOrderDetail = await AddOrderDetailsAsync(orderId);
                if (!addOrderDetail) { return null; }
                await _context.SaveChangesAsync();

                var getInfoOrder = await GetInfoOrderAsync(orderId);
                if (getInfoOrder != null)
                {
                    return getInfoOrder;
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        public async Task<InfoOrder> GetInfoOrderAsync(Guid orderId)
        {
            var getInfoOrder = await (from order in _context.Orders
                                      where order.Id == orderId
                                      select new InfoOrder
                                      {
                                          Id = order.Id,
                                          UserId = order.UserId,
                                          CartId = order.CartId,
                                          Status = order.Status,
                                          CreatedTime = order.CreatedTime,
                                      }).FirstOrDefaultAsync();
            if (getInfoOrder == null)
            {
                return null;
            }
            else
            {
                return getInfoOrder;
            }
        }

        public async Task<List<InfoOrderDetail>> GetInfoOrderDetailAsync(Guid orderId)
        {
            var getInfoOrderDetail = await (from orderDetail in _context.OrderDetails
                                            where orderDetail.OrderId == orderId
                                            select new InfoOrderDetail
                                            {
                                                OrderId= orderDetail.OrderId,
                                                ProductId= orderDetail.ProductId,
                                                ProductName= orderDetail.ProductName,
                                                Price = orderDetail.Price,
                                                Quantity = orderDetail.Quantity,
                                                CreatedTime = DateTime.UtcNow,
                                            }).ToListAsync();
            if (getInfoOrderDetail != null)
            {
                return getInfoOrderDetail;
            }else
            {
                return null;
            }
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
