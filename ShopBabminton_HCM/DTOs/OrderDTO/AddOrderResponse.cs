using ShopBabminton_HCM.Models.Entities;

namespace ShopBabminton_HCM.DTOs.OrderDTO
{
    public class AddOrderResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public InfoOrder Order { get; set; }
        public List<InfoOrderDetail> OrderDetails { get; set; }
    }
}
