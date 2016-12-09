using MakeEvent.Web.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeEvent.Web.Models.Organization
{
    public class BookedServiceMvcViewModel
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }

        [LocalizedDisplay("BServiceVmName", typeof(App_LocalResources.Localization))]
        public string ServiceName { get; set; }

        [LocalizedDisplay("BServiceVmFio", typeof(App_LocalResources.Localization))]
        public string CustomerFio { get; set; }

        [LocalizedDisplay("BServiceVmDate", typeof(App_LocalResources.Localization))]
        public DateTime Date { get; set; }

        [LocalizedDisplay("BServiceVmPrice", typeof(App_LocalResources.Localization))]
        public decimal Price { get; set; }
    }
}