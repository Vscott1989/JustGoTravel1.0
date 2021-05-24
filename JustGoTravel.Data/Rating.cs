using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public double StarRating { get { var totalScore = HotelRating + FoodRating; return totalScore / 2; } }
        [Required, Range(0, 5)]
        public double HotelRating { get; set; }
        [Required, Range(0, 5)]
        public double FoodRating { get; set; }

        [ForeignKey(nameof(VacationPack))]
        public int VacationPackID { get; set; }
        public virtual VacationPack VacationPack { get; set; }

    }
}
