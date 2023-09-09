using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZenturyLoginsApp.Models.Entities;

namespace ZenturyLoginsApp.DataServices.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public virtual DbSet<Login> Logins { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}

