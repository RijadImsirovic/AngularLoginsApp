using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZenturyLoginsApp.Models.Entities;

namespace ZenturyLoginsApp.DataServices.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Login> Logins { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public AppDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Login>()
                .HasOne(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}

