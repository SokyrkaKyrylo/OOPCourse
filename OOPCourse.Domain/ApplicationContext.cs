using Microsoft.EntityFrameworkCore;
using OOPCourse.Domain.Models;

namespace OOPCourse.Domain
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Assassin> Assassins { get; set; }
        public DbSet<Beggar> Beggars { get; set; }
        public DbSet<Thief> Thieves { get; set; }
        public DbSet<Fool> Fools { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
