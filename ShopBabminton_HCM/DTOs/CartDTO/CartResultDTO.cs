namespace ShopBabminton_HCM.DTOs.CartDTO
{
    public class CartResultDTO
    {
        public string Operation {  get; set; }
        public Guid CartDetailId { get; set; }
        public bool Stastus { get; set; }
        public string Message { get; set; }
    }
}
