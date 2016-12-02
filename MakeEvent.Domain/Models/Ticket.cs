using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeEvent.Domain.Models
{
    public class Ticket : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string PurchaserId { get; set; }
        public int CategoryId   { get; set; }
        public int TicketStatus { get; set; }

        [ForeignKey("PurchaserId")]
        public virtual ApplicationUser Purchaser { get; set; }

        [ForeignKey("CategoryId")]
        public virtual TicketCategory Category { get; set; }
    }
}
