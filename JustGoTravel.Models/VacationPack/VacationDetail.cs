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

        public int AgentID { get; set; }

        [Display(Name = "FirstName")]
        public string AgentFirst { get; set; } 

        [Display(Name = "LastName")]
        public string AgentName { get; set; } 

        [MaxLength(100, ErrorMessage = "Sorry you entered to many Charachers")]
        [Display(Name = "Title of Vacation Package ")]
        public string Title { get; set; }

        [Display(Name = "days of Trip")]
        public int TripLength { get; set; }

        [Display(Name = "Package Price")]
        public double TotalCost { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(GroupName = "What is included?")]
        public string Included { get; set; }

        [Display(Name = "Comments")]
        public string Description { get; set; }

        [Display(Name ="Created")]
        public DateTimeOffset TimeOfPublication { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public Double RatingStarRating { get; set; }


    }
}
