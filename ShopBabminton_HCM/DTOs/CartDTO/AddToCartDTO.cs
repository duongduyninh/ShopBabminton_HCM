namespace ShopBabminton_HCM.DTOs.CartDTO
{
    public class AddToCartDTO
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public int Quantity { get; set; }
    }
}
