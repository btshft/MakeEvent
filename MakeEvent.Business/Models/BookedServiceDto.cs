using System;

namespace MakeEvent.Business.Models
{
    public class BookedServiceDto
    {
        public int Id { get; set; }

        public int ServiceId { get; set; }

        public string CustomerFio { get; set; }

        public DateTime? BookedDate { get; set; }

        public string ServiceName { get; set; }

        public decimal Price { get; set; }
    }
}
