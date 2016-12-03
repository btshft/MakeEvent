using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeEvent.Domain.Models
{
    public class TicketCategory : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EventId { get; set; }

        public string  Type        { get; set; }
        public string  Description { get; set; }
        public decimal Price       { get; set; }
        public int     MaxCount    { get; set; }
        public int     BookedCount { get; set; }

        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
            = new List<Ticket>();
    }
}
