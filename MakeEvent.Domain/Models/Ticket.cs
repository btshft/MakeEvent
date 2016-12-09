using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeEvent.Domain.Models
{
    public class Ticket : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CategoryId     { get; set; }

        public string OwnerFirstName { get; set; }
        public string OwnerLastName  { get; set; }
        public string OwnerPhone     { get; set; }
        public string OwnerEmail     { get; set; }

        public bool IsPaid           { get; set; }

        public DateTime? BookDate    { get; set; }

        [ForeignKey("CategoryId")]
        public virtual TicketCategory Category { get; set; }
    }
}
