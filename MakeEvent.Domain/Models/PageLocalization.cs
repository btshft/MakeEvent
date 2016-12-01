using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeEvent.Domain.Models
{
    public class PageLocalization : Entity
    {
        [Key, Column(Order = 0)]
        public int PageId { get; set; }
        [Key, Column(Order = 1)]
        public int LanguageId { get; set; }


        public string Title { get; set; }
        public string Html  { get; set; }

        public virtual Page Page { get; set; }
        public virtual Language Language { get; set; }
    }
}
