using Microsoft.EntityFrameworkCore;
using LifeBand_backend.Models;

namespace LifeBand_backend.Data
{
    public class LifeBandDbContext : DbContext
    {
        public LifeBandDbContext(DbContextOptions<LifeBandDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
