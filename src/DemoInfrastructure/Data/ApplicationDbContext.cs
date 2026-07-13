using DemoDomain.Entities;
using DemoInfrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoInfrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser,
           ApplicationRole,
           Guid,
           ApplicationUserClaim,
           ApplicationUserRole,
           ApplicationUserLogin,
           ApplicationRoleClaim, 
           ApplicationUserToken>(options)
    {
        public DbSet<Product> Products { get; set; }
    }
}
