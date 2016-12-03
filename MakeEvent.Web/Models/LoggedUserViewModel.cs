using MakeEvent.Web.Attributes;

namespace MakeEvent.Web.Models
{
    public class LoggedUserViewModel
    {
        public string Id   { get; set; }
        public string Role { get; set; }

        [LocalizedDisplay("UserUserName")]
        public string UserName   { get; set; }

        [LocalizedDisplay("UserFirstName")]
        public string FirstName  { get; set; }

        [LocalizedDisplay("UserMiddleName")]
        public string MiddleName { get; set; }

        [LocalizedDisplay("UserLastName")]
        public string LastName   { get; set; }
    }
}