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
        private readonly IAmountService _amountService;
        public PlanTypeController(IPlanTypeService planTypeService, IAmountService amountService)
        {
            _planTypeService = planTypeService;
            _amountService = amountService;
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            var model = _planTypeService.GetAllPlanTypesForList(4, 1, "", id);
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

            ViewBag.list = _planTypeService.DropDownTypesForPlan(id); // TYPY bazowe
            var model = new NewPlanTypeVm(){
                PlanId = id
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPlanType(NewPlanTypeVm model)
        {
            var nameOfType = model.NameOfType;
            var typeId = _amountService.GetTypeIdByName(nameOfType);
            model.TypeId = typeId;
            if (ModelState.IsValid)
            {
                var id = _planTypeService.AddPlanType(model);
                return RedirectToAction("Index", new { id = model.PlanId });
            }
            ViewBag.list = _planTypeService.DropDownTypesForPlan(model.Plan.Id);
            return View(model);
        }
        [HttpGet]
        public IActionResult EditPlanType(int id)
        {
            //ViewBag.list = _amountService.DropDownTypes();
            var planType = _planTypeService.GetPlanTypeForEdit(id);
            return View(planType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPlanType(NewPlanTypeVm model)
        {
            //var nameOfType = model.NameOfType;
            //var typeId = _amountService.GetTypeIdByName(nameOfType);
            //model.TypeId = typeId;
            if (ModelState.IsValid)
            {
                _planTypeService.UpdatePlanType(model);
                return RedirectToAction("Index", new { id = model.PlanId });
            }
            //ViewBag.list = _amountService.DropDownTypes();
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
            _planTypeService.DeletePlanType(model.Id);
            return RedirectToAction("Index", "Plan");
        }
        //public IActionResult Details(int id)
        //{
        //    var amount = _amountService.GetAmountForEdit(id);
        //    return View(amount);
        //}
    }
}
