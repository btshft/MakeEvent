using MakeEvent.Web.Models.Admin;
using MakeEvent.Web.Models.Organization;
using System.Collections.Generic;

namespace MakeEvent.Web.Models.Common
{
    public class EventAndCatMvcViewModel
    {
        public List<EventMvcViewModel> Events {get;set;}

        public List<EventCategoryMvcViewModel> Categories { get; set; }
    }
}