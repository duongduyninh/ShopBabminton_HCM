using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBabminton_HCM.Models.Entities
{
    [Table("RefreshTokens")]
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Revoked { get; set; }
        public string CreatedByIp { get; set; }
        public string RevokedByIp { get; set; }
        public string UserId { get; set; }

        public AppUser User { get; set; }
    }
}
