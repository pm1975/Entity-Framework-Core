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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Fluent API

            builder.Entity<Setting>(config =>
            {
                config.HasOne(x => x.User);
            });

            builder.Entity<ApplicationUser>(config =>
            {
                config.HasMany(x => x.Settings);
            });

            //wymagany PhoneNumber
            builder.Entity<ApplicationUser>(config =>
            {
                config.Property(x => x.PhoneNumber).IsRequired();
            });

            //name ograniczone do 100 znaków
            builder.Entity<Setting>(config =>
            {
                config.Property(x => x.Name).HasMaxLength(100);
            });
        }
    }
}
