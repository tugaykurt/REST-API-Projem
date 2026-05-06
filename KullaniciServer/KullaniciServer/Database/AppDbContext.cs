using KullaniciServer.Models;
using Microsoft.EntityFrameworkCore;

namespace KullaniciServer.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
    }
}
