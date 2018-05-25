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

    }
}