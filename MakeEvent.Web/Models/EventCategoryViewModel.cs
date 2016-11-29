using System.Collections.Generic;

namespace MakeEvent.Web.Models
{
    public class EventCategoryViewModel
    {
        public int Id { get; set; }

        public string DefaultName { get; set; }

        public ICollection<EventCategoryLocalizationViewModel> EventCategoryLocalizations { get; set; }
    }
}