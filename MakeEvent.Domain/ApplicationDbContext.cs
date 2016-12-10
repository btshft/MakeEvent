using System.Data.Entity;
using MakeEvent.Domain.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MakeEvent.Domain
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("AzureConnectionString", throwIfV1Schema: false)
        { }

        public virtual IDbSet<Page> Pages { get; set; }
        public virtual IDbSet<News> News { get; set; }
        public virtual IDbSet<Language> Languages { get; set; }
        public virtual IDbSet<Organization> Organizations { get; set; }
        public virtual IDbSet<Comment> Comments { get; set; }
        public virtual IDbSet<Event> Events { get; set; }
        public virtual IDbSet<EventCategory> EventCategories { get; set; }
        public virtual IDbSet<Ticket> Tickets { get; set; }
        public virtual IDbSet<TicketCategory> TicketCategories { get; set; }
        public virtual IDbSet<Image> Images { get; set; }
        public virtual IDbSet<Service> Services { get; set; }
        public virtual IDbSet<BookedService> BookedServices { get; set; }

        public virtual IDbSet<PageLocalization> PageLocalizations { get; set; }
        public virtual IDbSet<NewsLocalization> NewsLocalizations { get; set; }
        public virtual IDbSet<EventCategoryLocalization> EventCategoryLocalizations { get; set; }
        

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
