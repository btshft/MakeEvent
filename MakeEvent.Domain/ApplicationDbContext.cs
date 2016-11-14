using System.Data.Entity;
using MakeEvent.Domain.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MakeEvent.Domain
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MainDb", throwIfV1Schema: false)
        { }

        public virtual IDbSet<Page> Pages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Database.SetInitializer<ApplicationDbContext>(null);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
