namespace MakeEvent.Web.Models.Organization
{
    public class TicketMvcViewModel
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public decimal Price { get; set; }
        public int MaxCount { get; set; }
        public string Description { get; set; }
    }

}