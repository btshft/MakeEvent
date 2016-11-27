using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeEvent.Domain.Models
{
    public class NewsLocalization : Entity
    {
        [Key, Column(Order = 0)]
        public int NewsId { get; set; }
        [Key, Column(Order = 1)]
        public int LanguageId { get; set; }

        public string Header  { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }

        public virtual Language Language { get; set; }
        public virtual News News { get; set; }
    }
}
