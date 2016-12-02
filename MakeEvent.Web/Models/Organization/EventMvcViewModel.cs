using System;

namespace MakeEvent.Web.Models.Organization
{
    public class EventMvcViewModel
    {
        public int  Id               { get; set; }
        public int  CategoryId       { get; set; }
        public int? ImageId          { get; set; }
        public string OrganizationId { get; set; }

        public string Name            { get; set; }
        public string Description     { get; set; }
        public string ShortDescripton { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate   { get; set; }

        public string City   { get; set; }
        public string Street { get; set; }
        public string Office { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}