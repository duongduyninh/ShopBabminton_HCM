using System.ComponentModel.DataAnnotations;

namespace ShopBabminton_HCM.DTOs.AuthenticationDTO
{
    public class SignUpDTO
    {
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Username { get; set; }
    }
}
