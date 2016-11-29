using System.Collections.Generic;

namespace MakeEvent.Business.Models
{
    public class EventCategoryLocalizationDto
    {
        public int EventCategoryId { get; set; }
        public int LanguageId { get; set; }

        public string Name { get; set; }
    }
}
