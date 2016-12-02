using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeEvent.Domain.Models
{
    public class Image : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name     { get; set; }
        public string MimeType { get; set; }
        public byte[] Content  { get; set; }

        public virtual ICollection<News> News { get; set; }
            = new List<News>();

        public virtual ICollection<Organization> Organizations { get; set; }
            = new List<Organization>();

        public virtual ICollection<Event> Events { get; set; }
            = new List<Event>();
    }
}
