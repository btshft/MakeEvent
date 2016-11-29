using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeEvent.Domain.Models
{
    public class EventCategoryLocalization : Entity
    {
        [Key, Column(Order = 0)]
        public int EventCategoryId { get; set; }
        [Key, Column(Order = 1)]
        public int LanguageId { get; set; }

        public string Name { get; set; }

        public virtual EventCategory EventCategory { get; set; }
        public virtual Language Language { get; set; }
    }
}
