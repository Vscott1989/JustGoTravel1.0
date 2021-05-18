using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGoTravel.Data
{
   public class Rating
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Guid AuthorID { get; set; }

        [Required]
        public double StarRating { get; set; }
     
        public double HotelRating { get; set; }
        
        public double FoodRating { get; set; }

        public virtual ICollection<VacationPack> VacationPacks { get; set; } = new List<VacationPack>();
    }
}
