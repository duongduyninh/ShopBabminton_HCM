namespace ShopBabminton_HCM.DTOs.OrderDTO
{
    public class InfoOrder
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid CartId { get; set; }
        public int Status { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}