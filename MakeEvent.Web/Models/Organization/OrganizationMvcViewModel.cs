using MakeEvent.Web.Attributes;

namespace MakeEvent.Web.Models.Organization
{
    public class OrganizationMvcViewModel
    {
        public string OwnerId { get; set; }
        public int?   ImageId { get; set; }

        [LocalizedDisplay("OrganizationVmName", typeof(App_LocalResources.Localization))]
        public string Name        { get; set; }

        [LocalizedDisplay("OrganizationVmEmail", typeof(App_LocalResources.Localization))]
        public string Email       { get; set; }

        [LocalizedDisplay("OrganizationVmPassword", typeof(App_LocalResources.Localization))]
        public string Password    { get; set; }

        [LocalizedDisplay("OrganizationVmDescription", typeof(App_LocalResources.Localization))]
        public string Description { get; set; }

        [LocalizedDisplay("OrganizationVmPhoneNumber", typeof(App_LocalResources.Localization))]
        public string PhoneNumber { get; set; }

        [LocalizedDisplay("OrganizationVmWebsite", typeof(App_LocalResources.Localization))]
        public string Website     { get; set; }

        [LocalizedDisplay("OrganizationVmCity", typeof(App_LocalResources.Localization))]
        public string City        { get; set; }

        [LocalizedDisplay("OrganizationVmStreet", typeof(App_LocalResources.Localization))]
        public string Street      { get; set; }

        [LocalizedDisplay("OrganizationVmOffice", typeof(App_LocalResources.Localization))]
        public string Office      { get; set; }

        [LocalizedDisplay("OrganizationVmBillNumber", typeof(App_LocalResources.Localization))]
        public string BillNumber  { get; set; }

        public byte[] ImageData     { get; set; }
        public string ImageMimeType { get; set; }
    }
}