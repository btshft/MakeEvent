using System.ComponentModel.DataAnnotations;

namespace MakeEvent.Web.Models.Admin
{
    public class EventCategoryMvcViewModel
    {
        public int Id { get; set; }

        [Required]
        public string NameRu { get; set; }

        [Required]
        public string NameEn { get; set; }

        public string LocalizedName { get; set; }
    }
}