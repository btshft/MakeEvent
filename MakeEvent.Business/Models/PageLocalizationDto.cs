namespace MakeEvent.Business.Models
{
    public class PageLocalizationDto
    {
        public int PageId     { get; set; }
        public int LanguageId { get; set; }

        public string Html    { get; set; }
        public string Title   { get; set; }
    }
}
