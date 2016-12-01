using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeEvent.Web.Models.ViewModels.Admin
{
    public class PageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
        [UIHint("tinymce_jquery_full"),AllowHtml]
        public string ContentRu { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string ContentEn { get; set; }
    }
}