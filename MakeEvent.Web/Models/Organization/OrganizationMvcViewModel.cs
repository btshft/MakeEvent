namespace MakeEvent.Web.Models.Organization
{
    public class OrganizationMvcViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BillNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Office { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}