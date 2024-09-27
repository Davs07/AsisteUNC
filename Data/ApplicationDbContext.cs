using AsitenciaUNC_attemp_2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AsitenciaUNC_attemp_2.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //public DbSet<Usuario> Usuarios { get; set; } // Ya viene con IdentityDbContext
        public DbSet<Evento> Eventos { get; set; }
		public DbSet<Registro> Registros { get; set; }
		public DbSet<Asistencia> Asistencias { get; set; }
		public DbSet<Notificacion> Notificaciones { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Registro>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Registros)
                .HasForeignKey(r => r.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict); // Cambiar a Restrict o SetNull

            modelBuilder.Entity<Registro>()
                .HasOne(r => r.Evento)
                .WithMany(e => e.Registros)
                .HasForeignKey(r => r.IdEvento)
                .OnDelete(DeleteBehavior.Restrict); // Cambiar a Restrict o SetNull

            // Configurar RegistroId como único en Asistencia
            modelBuilder.Entity<Asistencia>()
                .HasIndex(a => a.RegistroId)
                .IsUnique();
        }
    }
}
