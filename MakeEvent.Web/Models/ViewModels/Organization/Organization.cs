﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeEvent.Web.Models.ViewModels.Organization
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BillNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Office { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}