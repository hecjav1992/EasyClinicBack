using EasyClinic.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace EasyClinic.Server
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuarios> user { get; set; }

    }
}
