using System.ComponentModel.DataAnnotations;

namespace ShopBabminton_HCM.DTOs.CategoryDTO
{
    public class UpdateCategoryRequest
    {
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public string NameCategory { get; set; }
        public string? Description { get; set; }
    }
}
