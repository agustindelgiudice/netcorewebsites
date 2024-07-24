using System;

namespace NetCoreWebsitesBL.Data
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; } 
        public string Password { get; set; } 
        public string Email { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public DateTime FechaCreacion { get; set; } 
        public DateTime FechaModificacion { get; set; } 
        public bool IsActive { get; set; } 
        public bool IAgree { get; set; } 
        
        // Constructor
        public Usuario()
        {
            Username = "";
            Password = "";
            Email = "";
            FirstName = "";
            LastName = "";
            FechaCreacion = DateTime.MinValue;
            FechaModificacion = DateTime.MinValue;
            IsActive = false;
            IAgree = false;
        }
    }
}
