using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MakeEvent.Domain.Models;

namespace MakeEvent.Business.Models
{
    public class EventDto
    {
        public int  Id        { get; set; }
        public int? ImageId   { get; set; }
        public int  CategoryId       { get; set; }
        public string OrganizationId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescripton { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public string Office { get; set; }
    }
}
