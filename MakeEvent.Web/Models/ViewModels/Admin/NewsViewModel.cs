using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeEvent.Web.Models.ViewModels.Admin
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        public string TitleRu { get; set; }
        public string ShortDescriptionRu { get; set; }
        public string ContentRu { get; set; }
        public string TitleEn { get; set; }
        public string ShortDescriptionEn { get; set; }
        public string ContentEn { get; set; }

    }
}