using System;
using Microsoft.AspNetCore.Identity;

namespace NetCoreWebsitesBL.Models
{
    public class Usuario : IdentityUser
    {

        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public DateTime FechaCreacion { get; set; } 
        public DateTime FechaModificacion { get; set; } 
        public bool IsActive { get; set; } 
        public bool IAgree { get; set; } 
        
        // Constructor
        public Usuario()
        {
            FirstName = "";
            LastName = "";
            FechaCreacion = DateTime.MinValue;
            FechaModificacion = DateTime.MinValue;
            IsActive = false;
            IAgree = false;
        }
    }
}
