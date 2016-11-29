using System.Collections.Generic;

namespace MakeEvent.Business.Models
{
    public class EventCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<EventCategoryLocalizationDto> EventCategoryLocalizations { get; set; }
    }
}
