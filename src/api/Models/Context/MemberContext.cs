using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class MemberContext : DbContext
    {
        public MemberContext(DbContextOptions<MemberContext> dbContextOptions) :
            base(dbContextOptions)
        {
        }

        public DbSet<MemberModel> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberModel>()
                        .HasKey(m => m.Id);
        }
    }
}