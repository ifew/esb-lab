using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class UtilityContext : DbContext
    {
        public UtilityContext(DbContextOptions<UtilityContext> dbContextOptions) :
            base(dbContextOptions)
        {
        }

        public DbSet<Zipcode> Zipcode { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zipcode>()
                        .HasKey(m => new { m.PROVINCE_CODE, m.AMPHUR_CODE, m.TAMBOL_CODE });
        }
    }
}