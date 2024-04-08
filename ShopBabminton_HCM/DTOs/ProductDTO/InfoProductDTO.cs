namespace ShopBabminton_HCM.DTOs.ProductDTO
{
    public class InfoProductDTO
    {
        public Guid ProductId { get; set; }
        public string NameProduct { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public string CategoryName { get; set; }
    }
}
