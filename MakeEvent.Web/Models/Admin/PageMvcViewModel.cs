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

        [Required, AllowHtml]
        public string ContentRu { get; set; }

        [Required, AllowHtml]
        public string ContentEn { get; set; }
    }
}