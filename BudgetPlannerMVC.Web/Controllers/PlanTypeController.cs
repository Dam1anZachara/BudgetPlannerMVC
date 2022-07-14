using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.PlanView;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Web.Controllers
{
    public class PlanTypeController : Controller
    {
        private readonly IPlanTypeService _planTypeService;

        public PlanTypeController(IPlanTypeService planTypeService)
        {
            _planTypeService = planTypeService;
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            var model = _planTypeService.GetAllPlanTypesForList(8, 1, "", id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString, int id)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _planTypeService.GetAllPlanTypesForList(pageSize, pageNo.Value, searchString, id);
            return View(model);
        }
        [HttpGet]
        public IActionResult AddPlanType(int id)
        {
            var planTypes = _planTypeService.DropDownTypesForPlan(id);
            var model = new NewPlanTypeVm() {
                PlanId = id,
                PlanTypes = planTypes
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPlanType(NewPlanTypeVm model, int id)
        {
            if (ModelState.IsValid)
            {
                var planTypeId = _planTypeService.AddPlanType(model);
                return RedirectToAction("Index", new { id });
            }
            model.PlanTypes = _planTypeService.DropDownTypesForPlan(id);
            return View(model);
        }
        [HttpGet]
        public IActionResult EditPlanType(int id)
        {
            var planType = _planTypeService.GetPlanTypeForEdit(id);
            return View(planType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPlanType(NewPlanTypeVm model)
        {
            if (ModelState.IsValid)
            {
                _planTypeService.UpdatePlanType(model);
                return RedirectToAction("Index", new { id = model.PlanId });
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var planType = _planTypeService.GetPlanTypeForEdit(id);
            return View(planType);
        }
        [HttpPost]
        public IActionResult Delete(NewPlanTypeVm model)
        {
            var planId = _planTypeService.DeletePlanType(model.Id);
            return RedirectToAction("Index", new {id = planId});
        }
    }
}
