using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HireMe2.Models;

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
    }
}