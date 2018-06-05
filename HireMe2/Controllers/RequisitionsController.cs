using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HireMe2.Models;
using HireMe2.ViewModels;
using System.Data.Entity;

namespace HireMe2.Controllers
{
    public class RequisitionsController : Controller
    {

        private ApplicationDbContext _context;

        public RequisitionsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var requisitions = _context.Requisitions.Include(m => m.Genre).ToList();

            return View(requisitions);
        }


        // GET: Requisitions
        public ActionResult Details(int id)
        {
            var requisition = _context.Requisitions.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (requisition == null)
                return HttpNotFound();
            
            return View(requisition);
        }

        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new RequisitionFormViewModel
            {
                Genres = genres
            };

            return View("RequisitionForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var requisition = _context.Requisitions.SingleOrDefault(c => c.Id == id);

            if (requisition == null)
                return HttpNotFound();

            var viewModel = new RequisitionFormViewModel(requisition)
            {

                Genres = _context.Genres.ToList()
            };

            return View("RequisitionForm", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Requisition requisition)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new RequisitionFormViewModel(requisition)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("RequisitionForm", viewModel);
            }

            if(requisition.Id == 0)
            {
                requisition.DateOpened = DateTime.Now;
                _context.Requisitions.Add(requisition);

            }
            else
            {
                var requisitionInDb = _context.Requisitions.Single(m => m.Id == requisition.Id);
                requisitionInDb.Title = requisition.Title;
                requisitionInDb.GenreId = requisition.GenreId;
                requisitionInDb.NumberOfOpenings = requisition.NumberOfOpenings;
                requisitionInDb.DateOpened = requisition.DateOpened;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Requisitions");
        }

    }
}