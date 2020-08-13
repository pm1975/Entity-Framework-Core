using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Database
{
    public class WebApplication1DbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Setting> Settings { get; set; }
        //public DbSet<ApplicationUser> Users { get; set; }

        public WebApplication1DbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
