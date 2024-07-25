using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCoreWebsitesBL.Models;

namespace NetCoreWebsitesBL.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Registro> Registros { get; set; }
        public DbSet<LoginUsuario> LoginUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración adicional de la tabla Usuarios
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");

            // Clave primaria para Registro
            modelBuilder.Entity<Registro>()
                .HasKey(r => r.Id);
        }
    }
}
