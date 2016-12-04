using System.ComponentModel.DataAnnotations;
using MakeEvent.Web.Attributes;

namespace MakeEvent.Web.Models.Common
{
    public class LoginViewModel
    {
        [Required]
        [LocalizedDisplay("LoginVmEmail", typeof(App_LocalResources.Localization))]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [LocalizedDisplay("LoginVmPassword", typeof(App_LocalResources.Localization))]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }
}