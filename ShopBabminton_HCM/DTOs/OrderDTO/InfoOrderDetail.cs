namespace ShopBabminton_HCM.DTOs.OrderDTO
{
    public class InfoOrderDetail
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}