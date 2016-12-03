using MakeEvent.Web.Models.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeEvent.Web.Models.Common
{
    public class EventWithTicketsMvcViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Office { get; set; }
        public byte[] ImageData { get; set; }
        public List<TicketCategoryMvcViewModel> Tickets { get; set; }
        public SoldTicketMvcViewModel Ticket  { get; set; }
    }
}