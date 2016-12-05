using System;
using System.ComponentModel.DataAnnotations;
using Foolproof;
using MakeEvent.Web.Attributes;

namespace MakeEvent.Web.Models.Organization
{
    public class EventMvcViewModel
    {
        public int  Id               { get; set; }
        public int  CategoryId       { get; set; }
        public int? ImageId          { get; set; }
        public string OrganizationId { get; set; }

        [LocalizedDisplay("EventVmName", typeof(App_LocalResources.Localization))]
        public string Name            { get; set; }

        [LocalizedDisplay("EventVmDescription", typeof(App_LocalResources.Localization))]
        public string Description     { get; set; }

        [LocalizedDisplay("EventVmShortDescription", typeof(App_LocalResources.Localization))]
        public string ShortDescripton { get; set; }

        [LocalizedDisplay("EventVmStartDate", typeof(App_LocalResources.Localization))]
        public DateTime StartDate { get; set; } 

        [GreaterThan("StartDate")]
        [LocalizedDisplay("EventVmEndDate", typeof(App_LocalResources.Localization))]
        public DateTime EndDate   { get; set; }

        [LocalizedDisplay("EventVmCity", typeof(App_LocalResources.Localization))]
        public string City   { get; set; }

        [LocalizedDisplay("EventVmStreet", typeof(App_LocalResources.Localization))]
        public string Street { get; set; }

        [LocalizedDisplay("EventVmOffice", typeof(App_LocalResources.Localization))]
        public string Office { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}