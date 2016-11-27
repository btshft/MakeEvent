using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeEvent.Domain.Models
{
    public class Page : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name   { get; set; }
        public bool IsEditable { get; set; }

        public virtual ICollection<PageLocalization> PageLocalizations { get; set; }
            = new List<PageLocalization>();
    }
}
