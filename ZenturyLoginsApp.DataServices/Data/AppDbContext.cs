using Microsoft.EntityFrameworkCore;
using ZenturyLoginsApp.Models.Entities;

namespace ZenturyLoginsApp.DataServices.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Login> Logins { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasOne(u => u.User)
                .WithMany(l => l.Logins)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Login_User");
            });
        }
    }
}
