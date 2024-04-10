namespace ShopBabminton_HCM.DTOs.CartDTO
{
    public class GetInfoInCartResultDTO
    {
        public string UserId { get; set; }
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public int Quantity { get; set; }
    }
}
