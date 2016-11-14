namespace MakeEvent.Business.Models
{
    public class PageDto
    {
        public int Id { get; set; }
        public string PageName { get; set; }
        public bool IsEditable { get; set; }
        public string Html { get; set; }
    }
}
