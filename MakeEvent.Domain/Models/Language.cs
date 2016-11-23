using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeEvent.Domain.Models
{
    public class Language : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public bool IsDefault   { get; set; }

        public virtual ICollection<PageLocalization> PageLocalizations { get; set; }
            = new List<PageLocalization>();

        public virtual ICollection<NewsLocalization> NewsLocalizations { get; set; }
            = new List<NewsLocalization>();
    }
}
