using Microsoft.EntityFrameworkCore;

namespace SelfServiceCheckoutApi.Models
{
    //generating the database structure with EntityFramework
    public class StockDbContext : DbContext
    {
        public DbSet<Stock> Stock { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(@"Data Source=Stock.db");
    }
}
