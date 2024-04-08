using Microsoft.AspNetCore.Identity;

namespace ShopBabminton_HCM.Models.Entities
{
    public class AppUser : IdentityUser
    {
        public ICollection<Order> Order { get; set; }
    }
}
