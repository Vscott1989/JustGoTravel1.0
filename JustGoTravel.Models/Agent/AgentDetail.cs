using JustGoTravel.Models.VacationPack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGoTravel.Models.Agent
{
   public class AgentDetail
    {
        public int ID { get; set; }


        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Company { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public string LinkedIn { get; set; }



        public virtual ICollection<VacationPackListItemAgent> VacationPacks { get; set; } 
    }
}
