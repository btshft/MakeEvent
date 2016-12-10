using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeEvent.Domain.Models
{
    public class Organization : Entity
    {
        [Key, ForeignKey("Owner")]
        public string OwnerId { get; set; }

        public int? ImageId { get; set; }

        public string Name  { get; set; }
        public string BillNumber { get; set; }
        public string City    { get; set; }
        public string Street  { get; set; }
        public string Office  { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        [ForeignKey("ImageId")]
        public virtual Image Image { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
            = new List<Comment>();

        public virtual ICollection<Event> Events { get; set; }
             = new List<Event>();

        public virtual ICollection<Service> Services { get; set; }
            = new List<Service>();
    }
}
