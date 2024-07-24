using System.ComponentModel.DataAnnotations;

namespace NetCoreWebsitesBL.Models
{
    public class LoginUsuario
    {
         [Key]
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; } = false;
    }
}
