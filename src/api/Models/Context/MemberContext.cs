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
        public DbSet<AddressModel> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberModel>()
                        .HasKey(m => m.Id);

            modelBuilder.Entity<AddressModel>()
                        .HasKey(a => a.AddressId);

            modelBuilder.Entity<MemberModel>()
                        .HasMany(a => a.Addresses)
                        .WithOne(m => m.Members)
                        .HasForeignKey(a => a.Member_id);
        }

    }
}