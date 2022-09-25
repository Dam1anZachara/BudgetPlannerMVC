using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.AmountView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BudgetPlannerAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AmountController : ControllerBase
    {
        private readonly IAmountService _amountService;
        private readonly ITypeService _typeService;
        private readonly IBudgetUserService _budgetUserService;
        public AmountController(IAmountService amountService, ITypeService typeService, IBudgetUserService budgetUserService)
        {
            _amountService = amountService;
            _typeService = typeService;
            _budgetUserService = budgetUserService;
        }

        //[Authorize(Roles = "Admin, User")]
        [HttpGet]  
        public IActionResult GetAmount(int pageSize, int? pageNo, DateTime startDate, DateTime endDate)
        {
            FilterForAmountForListAmount filterForAmount = new();
            DateSelectForListAmountVm dateSelect = new()
            {
                StartDate = startDate,
                EndDate = endDate,
            };
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
            return Ok(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin, User")]
        public IActionResult AddAmount(NewAmountVm model)
        {
            var id = _amountService.AddAmount(model);
            return Created("", model);
        }
        [HttpPut]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin, User")]
        public IActionResult EditAmount(NewAmountVm model)
        {
            _amountService.UpdateAmount(model);
            return NoContent();
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin, User")]
        public IActionResult Delete(int id)
        {
            _amountService.DeleteAmount(id);
            return NoContent();
        }
    }
}
