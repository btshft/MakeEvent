namespace MakeEvent.Business.Models
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string OrganizationId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
