using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using magazin.Models;

namespace magazin.Models
{
    public class MobileContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<UserProfile> UserProfiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserProfile>().HasOne(m => m.User).WithOne(u => u.Profile)
            //               .HasForeignKey<UserProfile>(j => j.UserId);
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Login = "admin",
                    Password = "admin"
                }, new User()
                {
                    Id = 2,
                    Login = "Chototam",
                    Password = "Chototam"
                });
        }

        public MobileContext(DbContextOptions<MobileContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<magazin.Models.User> User { get; set; }

        
    }
}
