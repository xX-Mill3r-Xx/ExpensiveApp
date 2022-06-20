using ExpensiveControllApp.Models.Expensives;
using Microsoft.EntityFrameworkCore;

namespace ExpensiveControllApp.Infra.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Expensive> Expensives { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=localhost; Database=Expensive_DB; Trusted_Connection=True;");
    }
}
