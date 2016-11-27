using System.ComponentModel.DataAnnotations;

namespace MakeEvent.Web.Models
{
    public class EventCategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}