using MakeEvent.Web.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeEvent.Web.Models.Organization
{
    public class ServiceMvcViewModel
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }

        [LocalizedDisplay("ServiceVmName", typeof(App_LocalResources.Localization))]
        public string Name { get; set; }

        [LocalizedDisplay("ServiceVmDescription", typeof(App_LocalResources.Localization))]
        public string Description { get; set; }

        [LocalizedDisplay("ServiceVmPrice", typeof(App_LocalResources.Localization))]
        public decimal Price { get; set; }
    }
}