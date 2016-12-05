using MakeEvent.Web.Attributes;

namespace MakeEvent.Web.Models.Organization
{
    public class TicketCategoryMvcViewModel
    {
        public int Id      { get; set; }
        public int EventId { get; set; }

        [LocalizedDisplay("TicketVmType", typeof(App_LocalResources.Localization))]
        public string  Type        { get; set; }

        [LocalizedDisplay("TicketVmDescription", typeof(App_LocalResources.Localization))]
        public string  Description { get; set; }

        [LocalizedDisplay("TicketVmPrice", typeof(App_LocalResources.Localization))]
        public decimal Price       { get; set; }

        [LocalizedDisplay("TicketVmMaxCount", typeof(App_LocalResources.Localization))]
        public int     MaxCount    { get; set; }
    }

}