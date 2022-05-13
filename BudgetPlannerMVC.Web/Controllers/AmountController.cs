using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.AmountView;
using BudgetPlannerMVC.Application.ViewModels.TypeView;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BudgetPlannerMVC.Web.Controllers
{
    public class AmountController : Controller
    {
        private readonly IAmountService _amountService;
        public AmountController(IAmountService amountService)
        {
            _amountService = amountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _amountService.GetAllAmountsForList(3, 1, "");
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
            var model = _amountService.GetAllAmountsForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }
        [HttpGet]
        public IActionResult AddAmount()
        {
            ViewBag.list = _amountService.DropDownTypes();
            return View(new NewAmountVm());
        }
        [HttpPost]
        public IActionResult AddAmount(NewAmountVm model)
        {
            var nameOfType = model.NameOfType;
            var typeId = _amountService.GetTypeIdByName(nameOfType);
            model.TypeId = typeId;
            var id = _amountService.AddAmount(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditAmount(int id)
        {
            ViewBag.list = _amountService.DropDownTypes();
            var amount = _amountService.GetAmountForEdit(id);
            return View(amount);
        }
        [HttpPost]
        public IActionResult EditAmount(NewAmountVm model)
        {
            var nameOfType = model.NameOfType;
            var typeId = _amountService.GetTypeIdByName(nameOfType);
            model.TypeId = typeId;
            if (ModelState.IsValid)
            {
                _amountService.UpdateAmount(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var amount = _amountService.GetAmountForEdit(id);
            return View(amount);
        }
        [HttpPost]
        public IActionResult Delete(NewAmountVm model)
        {
            _amountService.DeleteAmount(model.Id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var amount = _amountService.GetAmountForEdit(id);
            return View(amount);
        }
    }
}
