using ShopBabminton_HCM.Models.Entities;

namespace ShopBabminton_HCM.DTOs.CategoryDTO
{
    public class AddCategoryResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; } 
        public CategoryInfo Category { get; set; }
    }
}
