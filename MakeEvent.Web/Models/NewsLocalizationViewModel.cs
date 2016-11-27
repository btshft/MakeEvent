using System.ComponentModel.DataAnnotations;

namespace MakeEvent.Web.Models
{
    public class NewsLocalizationViewModel
    {
        public int NewsId { get; set; }
        public int LanguageId { get; set; }

        [Required]
        public string Header { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ShortDescription { get; set; }
    }
}