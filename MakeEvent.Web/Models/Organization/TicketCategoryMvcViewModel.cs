namespace MakeEvent.Web.Models.Organization
{
    public class TicketCategoryMvcViewModel
    {
        public int Id      { get; set; }
        public int EventId { get; set; }

        public string  Type        { get; set; }
        public string  Description { get; set; }
        public decimal Price       { get; set; }
        public int     MaxCount    { get; set; }
    }

}