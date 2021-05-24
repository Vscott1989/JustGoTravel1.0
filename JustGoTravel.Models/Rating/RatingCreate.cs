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

        [Range(0,5), Display(Name = "Hotel Rating")]
        public double HotelRating { get; set; }

        [Range(0, 5), Display(Name = "Food Rating")]
        public double FoodRating { get; set; }
        public int VacationPackID { get; set; }
    }
}
