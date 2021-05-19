using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGoTravel.Models.VacationPack
{
   public class VacationDetail
    {        
        public int ID { get; set; }
        [Required]
        public int AgentID { get; set; }

        [Required]
        [Display(Name = "Title of Vacation Package")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Length of Trip ")]
        public int TripLength { get; set; }

        [Required]
        [Display(Name = "Package Cost")]
        public double TotalCost { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [Display(GroupName = "What is included?")]
        public string Included { get; set; }

        [Display(Name = "Comments")]
        public string Description { get; set; }
        [Display(Name = "Date Posted")]
        public DateTimeOffset TimeOfPublication { get; set; }
        [Display(Name = "Date Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual ICollection<VacationPackListItemRating> Ratings { get; set; }
    }
}
