namespace MakeEvent.Domain.Models
{
    public class Page : Entity<int>
    {
        public string PageName { get; set; }
        public bool IsEditable { get; set; }
        public string Html { get; set; }
    }
}
