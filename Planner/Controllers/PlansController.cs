using Planner.Entities;
using Planner.Entities.Models;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planner.Controllers
{
    public class PlansController : Controller
    {
        private readonly EFContext _context;
        public PlansController()
        {
            _context = new EFContext();
        }
        // GET: Plans
        public ActionResult ListPlans()
        {
            IEnumerable<PlanViewModel> models = _context.Plans.Select(m => new PlanViewModel
            {
                Title = m.Title,
                Description = m.Description,
                Image = m.Image,
                Date = m.Date,
                IsPriority = m.IsPriority
            });
            return View(models);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AddViewModel model)
        {
            Plan plan = new Plan 
            { 
                Title = model.Title,
                Description = model.Description,
                Date = model.Date,
                Image = model.Image,
                IsPriority = false
            };
            _context.Plans.Add(plan);
            _context.SaveChanges();
            return RedirectToAction("ListPlans");
        }
    }
}