namespace MakeEvent.Business.Models
{
    public class TicketCategoryDto
    {
        public int Id      { get; set; }
        public int EventId { get; set; }

        public string  Type        { get; set; }
        public string  Description { get; set; }
        public decimal Price       { get; set; }
        public int     MaxCount    { get; set; }
        public int     BookedCount { get; set; }
    }
}
