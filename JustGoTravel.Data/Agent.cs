using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGoTravel.Data
{
   public class Agent
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage = "Fist name should be between 3-25 characters")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage = "Fist name should be between 3-25 characters")]
        public string LastName { get; set; }
        public string Company { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Sorry to many Numbers")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public string LinkedIn { get; set; }
        public virtual ICollection<VacationPack> VacationPacks { get; set; } = new List<VacationPack>();
    }
}
