using EasyClinic.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace EasyClinic.Server
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<Atencion> Atencion { get; set; }
    }
}
