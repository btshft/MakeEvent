using System.ComponentModel.DataAnnotations;

namespace MakeEvent.Web.Models
{
    public class OrganizationViewModel
    {
        public string OwnerId { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Description { get; set; }

        [Required, Url]
        public string Website { get; set; }

        //[Required]
        public string EncodedLogo { get; set; }
    }
}