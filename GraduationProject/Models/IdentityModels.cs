using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GraduationProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
     
        public string Name { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Tags> Tags { get; set; }
        public DbSet<PostTable> PostTable { get; set; }
        public DbSet<TagUserTable> TagUserTable { get; set; }
        public DbSet<TalentedUser> TalentedUser { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Workshops> Workshops { get; set; }
        public DbSet<WorkshopForm> WorkshopForms { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<JobApplicationPost> JobApplicationPost { get; set; }
        public DbSet<TalentAcquisition> TalentAcquisition { get; set; }
        public DbSet<EventUserTable> EventUserTable { get; set; }
        public DbSet<WorkshopUserTable> WorkshopUserTable { get; set; } 
        public DbSet<AboutMeTagsUSerTable> AboutMeTagsUserTable { get; set; }
        public DbSet<Attendance> Attendance { get; set; }


        public DbSet<JobForm> JobForm { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>().HasRequired(a => a.Attendee).WithMany().WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}