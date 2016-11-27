namespace MakeEvent.Business.Models
{
    public class NewsLocalizationDto
    {
        public int NewsId { get; set; }
        public int LanguageId { get; set; }

        public string Header  { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
    }
}
