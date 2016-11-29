using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeEvent.Domain.Models
{
    public class EventCategory : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual ICollection<EventCategoryLocalization> EventCategoryLocalizations { get; set; }
            = new List<EventCategoryLocalization>();

        public virtual ICollection<Event> Events { get; set; }
            = new List<Event>();
    }
}
