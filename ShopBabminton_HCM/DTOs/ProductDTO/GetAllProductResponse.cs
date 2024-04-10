namespace ShopBabminton_HCM.DTOs.ProductDTO
{
    public class GetAllProductResponse
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string CategoryName { get; set; }
    }
}
