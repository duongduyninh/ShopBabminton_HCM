namespace ShopBabminton_HCM.DTOs.OrderDTO
{
    public class OrderResultDTO
    {
        public string Operation {  get; set; }
        public string UserId { get; set; }
        public Guid OrderId { get; set; }
        public bool Status {  get; set; }
        public string Message { get; set; }
    }
}
