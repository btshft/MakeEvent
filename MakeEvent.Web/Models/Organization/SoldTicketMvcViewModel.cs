﻿using System;

namespace MakeEvent.Web.Models.Organization
{
    public class SoldTicketMvcViewModel
    {
        public int Id { get; set; }
        public int TicketTypeId { get; set; }
        public string Owner { get; set; }
        public string EventTitle {get;set;}
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
        public string Status { get; set; }
    }
}