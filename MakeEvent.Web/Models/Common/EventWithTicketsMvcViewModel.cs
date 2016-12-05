using MakeEvent.Web.Models.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MakeEvent.Web.Attributes;

namespace MakeEvent.Web.Models.Common
{
    public class EventWithTicketsMvcViewModel
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

        public List<TicketCategoryMvcViewModel> Tickets { get; set; }
        public SoldTicketMvcViewModel Ticket  { get; set; }
    }
}