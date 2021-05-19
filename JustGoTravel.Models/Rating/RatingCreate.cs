using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGoTravel.Models.Rating
{
   public class RatingCreate
    {
        [Display(Name = "StarRating")]
        public double StarRating { get; set; }

        [Display(Name = "Hotel Rating")]
        public double HotelRating { get; set; }

        [Display(Name = "Food Rating")]
        public double FoodRating { get; set; }
        public int VacationPackID { get; set; }
    }
}
