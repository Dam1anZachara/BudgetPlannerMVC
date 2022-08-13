using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.AmountView;
using BudgetPlannerMVC.Application.ViewModels.TypeView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BudgetPlannerMVC.Web.Controllers
{
    [Authorize]
    public class AmountController : Controller
    {
        private readonly IAmountService _amountService;
        private readonly ITypeService _typeService;
        private readonly IBudgetUserService _budgetUserService;
        private readonly IUserRoleService _userRoleService;
        public AmountController(IAmountService amountService, ITypeService typeService, IBudgetUserService budgetUserService, IUserRoleService userRoleService)
        {
            _amountService = amountService;
            _typeService = typeService;
            _budgetUserService = budgetUserService;
            _userRoleService = userRoleService; 
        }
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Index()
        {
            DateTime startDate = new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: 1);
            DateTime endDate = new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day, hour:23, minute: 59, second:59, millisecond:999);
            var budgetUsers = _budgetUserService.DropDownBudgetUsers();
            var types = _typeService.DropDownTypes();
            FilterForAmountForListAmount filterForAmount = new FilterForAmountForListAmount()
            {
                SearchTypeId = 0,
                SearchUserId = 0,
                BudgetUsers = budgetUsers,
                Types = types
            };
            var dateSelect = _amountService.GetDateSelect(startDate, endDate); 
            var amounts = _amountService.GetFiltredAmountsForList(filterForAmount, dateSelect);
            var sumValues = _amountService.GetSumValuesForListAmount(amounts);
            var typeUserName = _amountService.SelectedUserNameForListAmount(filterForAmount);
            var model = _amountService.GetAllAmountsForList(6, 1, sumValues, typeUserName, amounts, dateSelect);
            model.FilterForAmount = filterForAmount;
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Index(int pageSize, int? pageNo, FilterForAmountForListAmount filterForAmount, DateSelectForListAmountVm dateSelect)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            filterForAmount.BudgetUsers = _budgetUserService.DropDownBudgetUsers();
            filterForAmount.Types = _typeService.DropDownTypes();
            var amounts = _amountService.GetFiltredAmountsForList(filterForAmount, dateSelect);
            var sumValues = _amountService.GetSumValuesForListAmount(amounts);
            var typeUserName = _amountService.SelectedUserNameForListAmount(filterForAmount);
            var model = _amountService.GetAllAmountsForList(pageSize, pageNo.Value, sumValues, typeUserName, amounts, dateSelect);
            model.FilterForAmount = filterForAmount;
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult AddAmount()
        {
            var types = _typeService.DropDownTypes();
            var budgetUsers = _budgetUserService.DropDownBudgetUsers();
            var currentUserId = _userRoleService.GetCurrentUserId();
            var budgetUserId = _budgetUserService.GetBudgetUserIdLoggedIn(currentUserId);
            var model = new NewAmountVm()
            {
                Types = types,
                BudgetUsers = budgetUsers,
                BudgetUserId = budgetUserId
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public IActionResult AddAmount(NewAmountVm model)
        {
            if (ModelState.IsValid)
            {
                var id = _amountService.AddAmount(model);
                return RedirectToAction("Index");
            }
            model.Types = _typeService.DropDownTypes();
            model.BudgetUsers = _budgetUserService.DropDownBudgetUsers();
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult EditAmount(int id)
        {
            var amount = _amountService.GetAmountForEdit(id);
            amount.Types = _typeService.DropDownTypes();
            amount.BudgetUsers = _budgetUserService.DropDownBudgetUsers();
            return View(amount);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public IActionResult EditAmount(NewAmountVm model)
        {
            if (ModelState.IsValid)
            {
                _amountService.UpdateAmount(model);
                return RedirectToAction("Index");
            }
            model.Types = _typeService.DropDownTypes();
            model.BudgetUsers = _budgetUserService.DropDownBudgetUsers();
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Delete(int id)
        {
            var amount = _amountService.GetAmountForEdit(id);
            return View(amount);
        }
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Delete(NewAmountVm model)
        {
            _amountService.DeleteAmount(model.Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Details(int id)
        {
            var amount = _amountService.GetAmountForEdit(id);
            return View(amount);
        }
    }
}
