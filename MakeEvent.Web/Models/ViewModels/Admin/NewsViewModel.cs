using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeEvent.Web.Models.ViewModels.Admin
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        public string TitleRu { get; set; }
        public string ShortDescriptionRu { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string ContentRu { get; set; }
        public string TitleEn { get; set; }
        public string ShortDescriptionEn { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string ContentEn { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}