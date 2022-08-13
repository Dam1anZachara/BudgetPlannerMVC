using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.PlanView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BudgetPlannerMVC.Web.Controllers
{
    [Authorize]
    public class PlanController : Controller
    {
        private readonly IPlanService _planService;
        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Index()
        {
            var model = _planService.GetAllPlansForList(8, 1, "");
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _planService.GetAllPlansForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult AddPlan()
        {
            return View(new NewPlanVm());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public IActionResult AddPlan(NewPlanVm model)
        {
            if (ModelState.IsValid)
            {
                var id = _planService.AddPlan(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult EditPlan(int id)
        {
            var plan = _planService.GetPlanForEdit(id);
            return View(plan);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public IActionResult EditPlan(NewPlanVm model)
        {
            if (ModelState.IsValid)
            {
                _planService.UpdatePlan(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Delete(int id)
        {
            var plan = _planService.GetPlanForEdit(id);
            return View(plan);
        }
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Delete(NewPlanVm model)
        {
            _planService.DeletePlan(model.Id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin, User")]
        public IActionResult Status(int id)
        {
            var plans = _planService.StatusPlan(id);
            _planService.UpdateListOfPlans(plans);
            return RedirectToAction("Index");
        }
    }
}
