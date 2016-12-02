using System.Collections.Generic;

namespace MakeEvent.Business.Models
{
    public class NewsDto
    {
        public int Id  { get; set; }
        public int? ImageId { get; set; }

        public ICollection<NewsLocalizationDto> NewsLocalizations { get; set; }
    }
}
