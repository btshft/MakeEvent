using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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
        [UIHint("tinymce_jquery_full"),AllowHtml]
        public string ContentRu { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string ContentEn { get; set; }
    }
}