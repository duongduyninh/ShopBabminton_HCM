namespace ShopBabminton_HCM.DTOs.ProductDTO
{
    public class AddProductResultDTO
    {
        public Guid? ProductId { get; set; }
        public bool Status { get; set; }
        public string? ErrorMessage { get; set; }
        public Guid CategoryId { get; set; }
    }
}
