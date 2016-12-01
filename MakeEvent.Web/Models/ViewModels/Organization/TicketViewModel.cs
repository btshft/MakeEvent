using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeEvent.Web.Models.ViewModels.Organization
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public decimal Price { get; set; }
        public int MaxCount { get; set; }
        public string Description { get; set; }
    }

}