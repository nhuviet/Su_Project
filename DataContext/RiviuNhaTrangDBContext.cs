using Microsoft.EntityFrameworkCore;
using Su_Project.Models;

namespace Su_Project.DataContext
{
    public class RiviuNhaTrangDBContext : DbContext
    {
        public RiviuNhaTrangDBContext(DbContextOptions<RiviuNhaTrangDBContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

    }
}
