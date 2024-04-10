using System.ComponentModel.DataAnnotations;

namespace ShopBabminton_HCM.DTOs.CategoryDTO
{
    public class CategoryInfo
    {
        [Required]
        public string CategoryName { get; set; }    
        public string? Description { get; set; }
    }
}
