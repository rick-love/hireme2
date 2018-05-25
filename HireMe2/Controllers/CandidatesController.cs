using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HireMe2.Models;
using HireMe2.ViewModels;

namespace HireMe2.Controllers
{
    public class CandidatesController : Controller
    {
        private ApplicationDbContext _context;

        public CandidatesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CandidateFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CandidateForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Candidate candidate)
        {

            _context.Candidates.Add(candidate);
            _context.SaveChanges();

            return RedirectToAction("Index", "Candidates");
            //if (candidate.Id == 0)
            //    _context.Candidates.Add(candidate);

            //else
            //{
            //    var InDb = _context.Candidates.Single(c => c.Id == candidate.Id);

            //}

            //return View();
        }


        public ViewResult Index()
        {
            var candidates = _context.Candidates.Include(c => c.MembershipType).ToList();

            return View(candidates);
        }

        public ActionResult Details(int? id)
        {
            var candidate = _context.Candidates.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (candidate == null)
                return HttpNotFound();

            return View(candidate);
        }

        public ActionResult Edit(int id)
        {
            var candidate = _context.Candidates.SingleOrDefault(c => c.Id == id);

            if (candidate == null)
                return HttpNotFound();

            var viewModel = new CandidateFormViewModel
            {
                Candidate = candidate,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CandidateForm", viewModel);
        }
    }
}