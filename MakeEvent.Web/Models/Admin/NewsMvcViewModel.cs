using System.ComponentModel.DataAnnotations;

namespace MakeEvent.Web.Models.Admin
{
    public class NewsMvcViewModel
    {
        public int Id { get; set; }

        [Required]
        public string TitleRu { get; set; }

        [Required]
        public string ShortDescriptionRu { get; set; }

        [Required]
        public string ContentRu { get; set; }

        [Required]
        public string TitleEn { get; set; }

        [Required]
        public string ShortDescriptionEn { get; set; }

        [Required]
        public string ContentEn { get; set; }
    }
}