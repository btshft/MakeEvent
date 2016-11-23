using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeEvent.Domain.Models
{
    public class Event : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int OrganizationId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescripton { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string City   { get; set; }
        public string Street { get; set; }
        public string Office { get; set; }

        [ForeignKey("CategoryId")]
        public virtual EventCategory Category { get; set; }

        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }

        public virtual ICollection<TicketCategory> TicketCategories { get; set; }
    }
}
