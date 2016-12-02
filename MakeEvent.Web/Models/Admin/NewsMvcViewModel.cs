using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MakeEvent.Web.Models.Admin
{
    public class NewsMvcViewModel
    {
        public int Id { get; set; }

        public int? ImageId { get; set; }

        [Required]
        public string TitleRu { get; set; }

        [Required]
        public string ShortDescriptionRu { get; set; }

        [Required, UIHint("tinymce_jquery_full"), AllowHtml]
        public string ContentRu { get; set; }

        [Required]
        public string TitleEn { get; set; }

        [Required]
        public string ShortDescriptionEn { get; set; }

        [Required, UIHint("tinymce_jquery_full"), AllowHtml]
        public string ContentEn { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        public string LocalizedTitle { get; set; }
        public string LocalizedShortDescription { get; set; }
        public string LocalizedContent { get; set; }
    }
}