using EasyClinic.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace EasyClinic.Server
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pacientes>().Property(u => u.nombre)
                .HasColumnName("nombres_paciente");
        }

    }
}
