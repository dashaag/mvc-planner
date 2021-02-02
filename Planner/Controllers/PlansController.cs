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
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                Image = m.Image,
                Date = m.Date,
                IsPriority = m.IsPriority
            });
            return View(models);
        }
        
        public ActionResult Calendar(DateTime date)
        {
            var model = _context.Plans.Where(x => x.Date == date).Select(n => new PlanViewModel 
            {
                Date = n.Date,
                Description = n.Description, 
                Id = n.Id,
                Image = n.Image,
                IsPriority = n.IsPriority,
                Title = n.Title
            });
            return PartialView(model);
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

        public ActionResult Delete(int id)
        {
            _context.Plans.Remove(_context.Plans.Find(id));
            _context.SaveChanges();
            return RedirectToAction("ListPlans");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Plan plan = _context.Plans.Find(id);
            PlanViewModel model = new PlanViewModel
            {
                Id = plan.Id,
                Date = plan.Date,
                Description = plan.Description,
                Image = plan.Image,
                IsPriority = plan.IsPriority,
                Title = plan.Title
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(PlanViewModel model)
        {
            Plan plan = _context.Plans.Find(model.Id);
            plan.Title = model.Title;
            plan.Image = model.Image;
            plan.IsPriority = model.IsPriority;
            plan.Date = model.Date;
            plan.Description = model.Description;
            _context.SaveChanges();
            return RedirectToAction("ListPlans");
        }

        public ActionResult Sort(string sort, int? order)
        {
            IEnumerable<PlanViewModel> model = _context.Plans.Select(m => new PlanViewModel()
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                Image = m.Image,
                Date = m.Date,
                IsPriority = m.IsPriority
            });
            switch (sort)
            {
                case "title":
                    {
                        model = model.OrderBy(ord => ord.Title);
                        break;
                    }
            }
            return View("ListPlans", model);
        }

    }
}