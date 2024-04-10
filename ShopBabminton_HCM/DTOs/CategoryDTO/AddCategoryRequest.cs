using System.ComponentModel.DataAnnotations;

namespace ShopBabminton_HCM.DTOs.CategoryDTO
{
    public class AddCategoryRequest
    {
        [Required]
        public string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
