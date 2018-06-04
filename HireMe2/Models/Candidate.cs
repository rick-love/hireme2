using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireMe2.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a valid name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool WillReceiveRequisitionPosting { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}