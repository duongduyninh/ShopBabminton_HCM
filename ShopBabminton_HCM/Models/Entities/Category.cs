using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBabminton_HCM.Models.Entities
{
    [Table("Categorys")]
    public class Category
    {
        public Guid Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string? Description { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
