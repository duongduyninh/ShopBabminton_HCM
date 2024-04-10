namespace ShopBabminton_HCM.DTOs.ProductDTO
{
    public class ProductInfo
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
        public int Status { get; set; }
    }
}
