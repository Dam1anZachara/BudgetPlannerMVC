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
        public IActionResult Index()
        {
            var model = _planTypeService.GetAllPlanTypesForList(4, 1, "", 0);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString, int planId)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _planTypeService.GetAllPlanTypesForList(pageSize, pageNo.Value, searchString, planId);
            return View(model);
        }
        [HttpGet]
        public IActionResult AddPlanType()
        {
            ViewBag.list = _amountService.DropDownTypes(); // TYPY bazowe
            return View(new NewPlanTypeVm());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPlanType(NewPlanTypeVm model, int planId)
        {
            var nameOfType = model.NameOfType;
            var typeId = _amountService.GetTypeIdByName(nameOfType);
            model.TypeId = typeId;
            model.PlanId = planId;
            if (ModelState.IsValid)
            {
                var id = _planTypeService.AddPlanType(model);
                return RedirectToAction("Index");
            }
            ViewBag.list = _amountService.DropDownTypes();
            return View(model);
        }
        //[HttpGet]
        //public IActionResult EditAmount(int id)
        //{
        //    ViewBag.list = _amountService.DropDownTypes();
        //    var amount = _amountService.GetAmountForEdit(id);
        //    return View(amount);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditAmount(NewAmountVm model)
        //{
        //    var nameOfType = model.NameOfType;
        //    var typeId = _amountService.GetTypeIdByName(nameOfType);
        //    model.TypeId = typeId;
        //    if (ModelState.IsValid)
        //    {
        //        _amountService.UpdateAmount(model);
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.list = _amountService.DropDownTypes();
        //    return View(model);
        //}
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var amount = _amountService.GetAmountForEdit(id);
        //    return View(amount);
        //}
        //[HttpPost]
        //public IActionResult Delete(NewAmountVm model)
        //{
        //    _amountService.DeleteAmount(model.Id);
        //    return RedirectToAction("Index");
        //}
        //public IActionResult Details(int id)
        //{
        //    var amount = _amountService.GetAmountForEdit(id);
        //    return View(amount);
        //}
    }
}
