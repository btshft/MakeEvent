using System.Collections.Generic;

namespace MakeEvent.Business.Models
{
    public class PageDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public bool IsEditable { get; set; }

        public virtual ICollection<PageLocalizationDto> PageLocalizations { get; set; }
            = new List<PageLocalizationDto>();
    }
}
