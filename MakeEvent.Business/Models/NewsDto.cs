using System.Collections.Generic;

namespace MakeEvent.Business.Models
{
    public class NewsDto
    {
        public int Id              { get; set; }

        public string EncodedImage { get; set; }
        public string AuthorId     { get; set; }

        public ICollection<NewsLocalizationDto> NewsLocalizations { get; set; }
    }
}
