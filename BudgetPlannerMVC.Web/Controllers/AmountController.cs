using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.AmountView;
using BudgetPlannerMVC.Application.ViewModels.TypeView;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
            DateTime startDate = new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: 1);
            DateTime endDate = new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day, hour:23, minute: 59, second:59);
            var dateSelect = _amountService.GetDateSelect(startDate, endDate);

            var model = _amountService.GetAllAmountsForList(6, 1, "", dateSelect);

            ////TEST FOR IDEX VM without SQL ****************
            //var assign = new AssignForTypeVm()
            //{
            //    Id = 1,
            //    Name = "ExpenseTest"
            //};
            //var type = new TypeForListVm()
            //{
            //    Id = 1,
            //    AssignId = 1,
            //    Name = "TestNoSQL",
            //    Assign = assign,
            //};
            //var amount = new AmountForListVm()
            //{
            //    Id = 1,
            //    Date = DateTime.Now,
            //    Type = type,
            //    TypeId = type.Id,
            //    Value = 200
            //};
            //var listAmount = new List<AmountForListVm>();
            //listAmount.Add(amount);
            //var model = new ListAmountForListVm() 
            //{
            //    Amounts = listAmount,
            //    DateSelect = dateSelect
            //};
            ////TEST END ************************************
            return View(model);
        }
        [HttpPost]
        //public IActionResult Index(int pageSize, int? pageNo, string searchString, DateTime startDate, DateTime endDate)
        public IActionResult Index(int pageSize, int? pageNo, string searchString, DateSelectForListAmountVm dateSelect)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _amountService.GetAllAmountsForList(pageSize, pageNo.Value, searchString, dateSelect);
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
