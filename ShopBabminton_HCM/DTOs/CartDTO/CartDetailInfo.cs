namespace ShopBabminton_HCM.DTOs.CartDTO
{
    public class CartDetailInfo
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}