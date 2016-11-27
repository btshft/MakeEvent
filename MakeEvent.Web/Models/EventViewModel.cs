using System;
using System.ComponentModel.DataAnnotations;

namespace MakeEvent.Web.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        [Required]
        public int? OrganizationId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ShortDescripton { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Office { get; set; }
    }
}