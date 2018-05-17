using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HireMe2.Models;
using HireMe2.ViewModels;

namespace HireMe2.Controllers
{
    public class RequisitionsController : Controller
    {
        // GET: Requisitions
        public ActionResult Index()
        {
            var requisitions = GetRequisitions();

            return View(requisitions);
        }

        private IEnumerable<Requisition> GetRequisitions()
        {
            return new List<Requisition>
            {
                new Requisition { Id = 1, Title = "Java Developer"},
                new Requisition { Id = 2, Title = "React Developer"}
            };
        }
    }
}