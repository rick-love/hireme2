using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HireMe2.Models;
using System.ComponentModel.DataAnnotations;

namespace HireMe2.Dtos
{
    public class CandidateDto
    {
        public int Id { get; set; }

            [Required(ErrorMessage = "Please enter a valid name")]
            [StringLength(255)]
            public string Name { get; set; }

            public bool WillReceiveRequisitionPosting { get; set; }
        
            public byte MembershipTypeId { get; set; }

            //[Min18YearsIfAMember]
            public DateTime? Birthdate { get; set; }
        
    }
}