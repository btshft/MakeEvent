using System.ComponentModel.DataAnnotations;

namespace MakeEvent.Web.Models
{
    public class EventCategoryLocalizationViewModel
    {
        public int EventCategoryId { get; set; }
        public int LanguageId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}