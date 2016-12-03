using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MakeEvent.Web.Attributes;

namespace MakeEvent.Web.Models.Admin
{
    public class NewsMvcViewModel
    {
        public int Id { get; set; }

        public int? ImageId { get; set; }

        [Required]
        [LocalizedDisplay("NewsTitleRu", typeof(App_LocalResources.Localization))]
        public string TitleRu { get; set; }

        [Required]
        [LocalizedDisplay("NewsDescriptionRu", typeof(App_LocalResources.Localization))]
        public string ShortDescriptionRu { get; set; }

        [Required, UIHint("tinymce_jquery_full"), AllowHtml]
        [LocalizedDisplay("NewsContentRu", typeof(App_LocalResources.Localization))]
        public string ContentRu { get; set; }

        [Required]
        [LocalizedDisplay("NewsTitleEn", typeof(App_LocalResources.Localization))]
        public string TitleEn { get; set; }

        [Required]
        [LocalizedDisplay("NewsDescriotionEn", typeof(App_LocalResources.Localization))]
        public string ShortDescriptionEn { get; set; }

        [Required, UIHint("tinymce_jquery_full"), AllowHtml]
        [LocalizedDisplay("NewsContentEn", typeof(App_LocalResources.Localization))]
        public string ContentEn { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        [LocalizedDisplay("NewsTitle", typeof(App_LocalResources.Localization))]
        public string LocalizedTitle { get; set; }

        [LocalizedDisplay("NewsTitle", typeof(App_LocalResources.Localization))]
        public string LocalizedShortDescription { get; set; }

        [LocalizedDisplay("NewsTitle", typeof(App_LocalResources.Localization))]
        public string LocalizedContent { get; set; }
    }
}