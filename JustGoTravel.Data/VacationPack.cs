using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGoTravel.Data
{
   public class VacationPack
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required, Range (1, 100)]
        public int TripLength { get; set; }

        [Required]
        public double TotalCost { get; set; }

        [Required]
        public string Location { get; set; }
        public string Description { get; set; }
        [Required]
        public string Included { get; set; }

        [Required]
        public DateTimeOffset TimeOfPublication { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        [Required]
        [ForeignKey(nameof(Agent))]
        public int AgentID { get; set; }
        public virtual Agent Agent { get; set; }

        

    }
}
