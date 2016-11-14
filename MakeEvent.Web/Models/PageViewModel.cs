using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MakeEvent.Web.Models
{
    public class PageViewModel
    {
        public int Id { get; set; }

        [Required]
        public string PageName { get; set; }

        public bool IsEditable { get; set; }

        [AllowHtml, Required]
        public string Html { get; set; }
    }
}