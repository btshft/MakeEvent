using System;
using MakeEvent.Web.Attributes;

namespace MakeEvent.Web.Models.Organization
{
    public class SoldTicketMvcViewModel
    {
        public int Id         { get; set; }

        [LocalizedDisplay("TicketVmCategory", typeof(App_LocalResources.Localization))]
        public int CategoryId { get; set; }

        [LocalizedDisplay("TicketVmOwnerFirstName", typeof(App_LocalResources.Localization))]
        public string OwnerFirstName  { get; set; }

        [LocalizedDisplay("TicketVmOwnerLastName", typeof(App_LocalResources.Localization))]
        public string OwnerLastName   { get; set; }

        [LocalizedDisplay("TicketVmOwnerPhone", typeof(App_LocalResources.Localization))]
        public string OwnerPhone      { get; set; }

        [LocalizedDisplay("TicketVmOwnerEmail", typeof(App_LocalResources.Localization))]
        public string OwnerEmail      { get; set; }

        [LocalizedDisplay("TicketVmEventTitle", typeof(App_LocalResources.Localization))]
        public string  EventTitle     { get; set; }

        [LocalizedDisplay("TicketVmCost", typeof(App_LocalResources.Localization))]
        public decimal Cost           { get; set; }

        [LocalizedDisplay("TicketVmStatus", typeof(App_LocalResources.Localization))]
        public string  Status         { get; set; }

        [LocalizedDisplay("TicketVmBookDate", typeof(App_LocalResources.Localization))]
        public DateTime? BookDate     { get; set; }
    }
}