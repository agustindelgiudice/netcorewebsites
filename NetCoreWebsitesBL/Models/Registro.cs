using System.ComponentModel.DataAnnotations;

namespace NetCoreWebsitesBL.Data
{
    public class Registro
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public bool IAgree { get; set; }
    }
}
