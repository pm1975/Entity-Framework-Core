using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Database
{
    public class WebApplication1DbContext : DbContext
    {
        public DbSet<Setting> Settings { get; set; }

        public WebApplication1DbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
