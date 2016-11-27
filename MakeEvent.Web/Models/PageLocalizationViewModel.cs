using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MakeEvent.Web.Models
{
    public class PageLocalizationViewModel
    {
        public int LanguageId  { get; set; }

        [Required]
        public string PageName { get; set; }

        [AllowHtml]
        public string Html     { get; set; }
    }
}