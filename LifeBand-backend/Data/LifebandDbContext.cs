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
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Pulseira> Pulseiras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>()
                .Property(f => f.Salario)
                .HasColumnType("decimal(18, 2)"); // 18 dígitos de precisão e 2 casas decimais

            base.OnModelCreating(modelBuilder);
        }
    }
}
