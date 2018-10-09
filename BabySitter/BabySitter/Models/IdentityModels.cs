using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BabySitter.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Child> Children { get; set; }
        
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}