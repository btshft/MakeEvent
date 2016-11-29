using System.Collections.Generic;

namespace MakeEvent.Business.Models
{
    public class OrganizationDto
    {
        public string OwnerId { get; set; }
        public string Name  { get; set; }
        public string Email { get; set; }
        public string Password    { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string City   { get; set; }
        public string Street { get; set; }
        public string Office { get; set; }
        public string EncodedLogo { get; set; }
    }
}
