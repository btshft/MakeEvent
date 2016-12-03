using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MakeEvent.Web.Attributes;

namespace MakeEvent.Web.Models.Admin
{
    public class PageMvcViewModel
    {
        public int Id { get; set; }

        [Required]
        [LocalizedDisplay("PageName", typeof(App_LocalResources.Localization))]
        public string Name { get; set; }

        [Required]
        [LocalizedDisplay("PageTitleRu", typeof(App_LocalResources.Localization))]
        public string TitleRu { get; set; }

        [Required]
        [LocalizedDisplay("PageTitleEn", typeof(App_LocalResources.Localization))]
        public string TitleEn { get; set; }

        [Required, UIHint("tinymce_jquery_full"), AllowHtml]
        [LocalizedDisplay("PageContentRu", typeof(App_LocalResources.Localization))]
        public string ContentRu { get; set; }

        [Required, UIHint("tinymce_jquery_full"), AllowHtml]
        [LocalizedDisplay("PageContentEn", typeof(App_LocalResources.Localization))]
        public string ContentEn { get; set; }

        [LocalizedDisplay("PageTitle", typeof(App_LocalResources.Localization))]
        public string LocalizedTitle { get; set; }

        [LocalizedDisplay("PageContent", typeof(App_LocalResources.Localization))]
        public string LocalizedContent { get; set; }
    }
}