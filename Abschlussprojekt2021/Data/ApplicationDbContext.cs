using Abschlussprojekt2021.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Abschlussprojekt2021.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JobAd> JobAds { get; set; }

        // Changing Identity table names when creating the database
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims"); //AspNetUserClaim
        //    builder.Entity<IdentityRole>().ToTable("Roles"); //AspNetRoles
        //    builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims"); //AspNetUserClaim
        //    builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins"); //AspNetUserLogin
        //    builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles"); //AspNetUserRole
        //    builder.Entity<ApplicationUser>().ToTable("Users"); //AspNetUsers
        //    builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens"); //AspNetUserToken
        //}
    }
}