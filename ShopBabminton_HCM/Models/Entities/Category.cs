using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBabminton_HCM.Models.Entities
{
    [Table("Categorys")]
    public class Category
    {
        public Guid Id { get; set; }
        public string NameCategory { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
