using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGoTravel.Models.VacationPack
{
   public class VacationCreate
    {
        public int AgentID { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Sorry you entered to many Charachers")]
        [Display(Name ="Title of Vacation Package ")]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Days of Trip")]
        public int TripLength { get; set; }

        [Required]
        [Display(Name ="Package Price")]
        public double TotalCost { get; set; }

        [Required]
        [Display(Name ="Location")]
        public string Location { get; set; }

        [Required]
        [Display(GroupName ="What is included?")]
        public string Included { get; set; }

        [Display(Name ="Comments")]
        public string Description { get; set; }

    }
}
