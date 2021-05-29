using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Display(Name = "Date Of Birth")]
        [Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MemberShipType MemberShipType { get; set; }

        [Display(Name = "MemberShip Type")]
        [Required]
        public byte MemberShipTypeId { get; set; }

        [StringLength(14, MinimumLength = 7,ErrorMessage = "Last name should be between 7 and 14 characters")]
        public String IDN { get; set; }
        [EmailAddress(ErrorMessage = "The e-mail should resperct the format xxx@xxx.xxx")]
        public String Email { get; set; }
        [Phone]
        public String Phone { get; set; }


    }
}