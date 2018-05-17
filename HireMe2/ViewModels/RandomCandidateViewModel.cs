using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HireMe2.Models;

namespace HireMe2.ViewModels
{
    public class RandomCandidateViewModel
    {
        public Candidate Candidate { get; set; }
        public List<Requisition> Requisitions { get; set; }
    }
}