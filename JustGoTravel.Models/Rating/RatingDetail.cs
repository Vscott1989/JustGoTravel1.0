using JustGoTravel.Models.VacationPack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGoTravel.Models.Rating
{
   public class RatingDetail
    {
        public int ID { get; set; }

        [Display(Name = "StarRating")]
        public double StarRating { get; set; }

        [Display(Name = "Hotel Rating")]
        public double HotelRating { get; set; }

        [Display(Name = "Food Rating")]
        public double FoodRating { get; set; }

        public virtual ICollection<VacationPackListItemRating> VacationPacks { get; set; }
    }
}
