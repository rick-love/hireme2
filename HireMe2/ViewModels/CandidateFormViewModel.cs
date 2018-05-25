using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HireMe2.Models;

namespace HireMe2.ViewModels
{
    public class CandidateFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Candidate Candidate { get; set; }
    }
}