using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.PlanView;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BudgetPlannerMVC.Web.Controllers
{
    public class PlanController : Controller
    {
        private readonly IPlanService _planService;
        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _planService.GetAllPlansForList(4, 1, "");
            return View(model);
        }
        [HttpPost]
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
        public IActionResult AddPlan()
        {
            //ViewBag.list = _typeService.DropDownAssigns();
            return View(new NewPlanVm());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPlan(NewPlanVm model)
        {
            //var nameOfAssign = model.NameOfAssign;
            //var assignId = _typeService.GetAssignIdByName(nameOfAssign);
            //model.AssignId = assignId;
            if (ModelState.IsValid)
            {
                var id = _planService.AddPlan(model);
                return RedirectToAction("Index");
            }
            //ViewBag.list = _typeService.DropDownAssigns();
            return View(model);
        }
        [HttpGet]
        public IActionResult EditPlan(int id)
        {
            //ViewBag.list = _typeService.DropDownAssigns();
            var plan = _planService.GetPlanForEdit(id);
            return View(plan);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPlan(NewPlanVm model)
        {
            //var nameOfAssign = model.NameOfAssign;
            //var assignId = _typeService.GetAssignIdByName(nameOfAssign);
            //model.AssignId = assignId;
            if (ModelState.IsValid)
            {
                _planService.UpdatePlan(model);
                return RedirectToAction("Index");
            }
            //ViewBag.list = _typeService.DropDownAssigns();
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var plan = _planService.GetPlanForEdit(id);
            return View(plan);
        }
        [HttpPost]
        public IActionResult Delete(NewPlanVm model)
        {
            _planService.DeletePlan(model.Id);
            return RedirectToAction("Index");
        }
        public IActionResult Status(int id)
        {
            var plans = _planService.StatusPlan(id);
            _planService.UpdateListOfPlans(plans);
            return RedirectToAction("Index");
        }
    }
}
