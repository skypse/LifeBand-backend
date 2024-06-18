using Microsoft.EntityFrameworkCore;
using LifeBand_backend.Models;

namespace LifeBand_backend.Data
{
    public class LifeBandDbContext : DbContext
    {
        // permitindo configuração de contexto como (Connection String e outras coisas que
        // possa ser injetado nessa inicialização)
        public LifeBandDbContext(DbContextOptions<LifeBandDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
