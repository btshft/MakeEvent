using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MakeEvent.Web.Models.Admin
{
    public class PageMvcViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string TitleRu { get; set; }

        [Required]
        public string TitleEn { get; set; }

        [Required, UIHint("tinymce_jquery_full"),AllowHtml]
        public string ContentRu { get; set; }

        [Required, UIHint("tinymce_jquery_full"), AllowHtml]
        public string ContentEn { get; set; }
    }
}