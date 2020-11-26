using Demo.Models.Authentication;
using Microsoft.EntityFrameworkCore;
using Demo.Models.Common;

namespace Demo.Infrastructure
{
    public class EntireContext : DbContext
    {
        public EntireContext(DbContextOptions<EntireContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForUser();

            modelBuilder.Entity<User>()
                .HasData(new[]
                {
                    new User(1, "me", new UserRef("DFE27E47-2BBE-4C7D-B419-25AC7835881F")),
                    new User(2, "neighbor", new UserRef("C8A9EFD2-F350-4437-ADA0-1CCB8C0DFA55")),
                });

            modelBuilder.ForProduct();
        }
    }
}
