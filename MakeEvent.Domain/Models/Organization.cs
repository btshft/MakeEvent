using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeEvent.Domain.Models
{
    public class Organization : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name  { get; set; }
        public string Phone { get; set; }
        public string BillNumber { get; set; }
        public string City   { get; set; }
        public string Street { get; set; }
        public string Office { get; set; }

        [Required]
        public virtual ApplicationUser Owner { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
            = new List<Comment>();

        public virtual ICollection<Event> Events { get; set; }
             = new List<Event>();
    }
}
