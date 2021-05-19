using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGoTravel.Models.VacationPack
{
   public class VacationListItem
    {
        [Display(Name = "ID")]
        public int ID { get; set; }
        public int AgentID { get; set; }
        [Display(Name = "Vacation Package Name")]
        public string Title { get; set; }
        [Display(Name = "Length of Trip")]
        public int TripLength { get; set; }
        [Display(Name = "Total Cost")]
        public double TotalCost { get; set; }
        [Display(Name = "City & Contry")]
        public string Location { get; set; }
        [Display(Name = "Comment")]
        public string Description { get; set; }
        [Display(Name = "What was Included in package?")]
        public string Included { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset TimeOfPublication { get; set; }

    }
    public class VacationPackListItemAgent
    {
        public int ID { get; set; }

        [Display(Name = "ID")]
        public string Title { get; set; }
        [Display(Name = "Length of Trip")]
        public int TripLength { get; set; }
        [Display(Name = "Total Cost")]
        public double TotalCost { get; set; }
        [Display(Name = "City & Contry")]
        public string Location { get; set; }
        [Display(Name = "Comment")]
        public string Description { get; set; }
        [Display(Name = "What was Included in package?")]
        public string Included { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset TimeOfPublication { get; set; }

    }
    public class VacationPackListItemRating
    {
        public int ID { get; set; }
        public int VacatonID { get; set; }
        public int AgentID { get; set; }

        [Display(Name = "Vacation Package Name")]
        public string Title { get; set; }
        [Display(Name = "Length of Trip")]
        public int TripLength { get; set; }
        [Display(Name = "Total Cost")]
        public double TotalCost { get; set; }
        [Display(Name = "City & Contry")]
        public string Location { get; set; }
        [Display(Name = "Comment")]
        public string Description { get; set; }
        [Display(Name = "What was Included in package?")]
        public string Included { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset TimeOfPublication { get; set; }

    }
}
