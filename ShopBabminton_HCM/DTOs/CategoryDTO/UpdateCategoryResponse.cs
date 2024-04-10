namespace ShopBabminton_HCM.DTOs.CategoryDTO
{
    public class UpdateCategoryResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public CategoryInfo Category { get; set; }
    }
}
