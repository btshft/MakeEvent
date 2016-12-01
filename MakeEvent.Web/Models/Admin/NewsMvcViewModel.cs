using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeEvent.Web.Models.Admin
{
    public class NewsMvcViewModel
    {
        public int Id { get; set; }

        [Required]
        public string TitleRu { get; set; }

        [Required]
        public string ShortDescriptionRu { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string ContentRu { get; set; }

        [Required]
        public string TitleEn { get; set; }

        [Required]
        public string ShortDescriptionEn { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string ContentEn { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}