using System.ComponentModel.DataAnnotations;
using MakeEvent.Web.Attributes;

namespace MakeEvent.Web.Models.Admin
{
    public class EventCategoryMvcViewModel
    {
        public int Id { get; set; }

        [Required]
        [LocalizedDisplay("EventCategoryNameRu", typeof(App_LocalResources.Localization))]
        public string NameRu { get; set; }

        [Required]
        [LocalizedDisplay("EventCategoryNameEn", typeof(App_LocalResources.Localization))]
        public string NameEn { get; set; }

        [LocalizedDisplay("EventCategoryName", typeof(App_LocalResources.Localization))]
        public string LocalizedName { get; set; }
    }
}