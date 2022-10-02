using BudgetPlannerMVC.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BudgetPlannerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetStatusController : ControllerBase
    {
        private readonly IBudgetStatusService _budgetStatusService;
        public BudgetStatusController(IBudgetStatusService budgetStatusService)
        {
            _budgetStatusService = budgetStatusService;
        }
        [SwaggerOperation("Operation gets active budget status")]
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public IActionResult Get()
        {
            var plan = _budgetStatusService.GetActivePlanToBudgetStatusVm();
            var planTypes = _budgetStatusService.GetPlanTypesOfPlanForBudgetStatusVm(plan);
            var amounts = _budgetStatusService.GetAmountsOutOfPlan(plan, planTypes);
            var sumValues = _budgetStatusService.GetSumValuesForBudgetStatusVm(planTypes, amounts);
            var model = _budgetStatusService.GetBudgetStatusForVm(planTypes, sumValues, plan);
            return Ok(model);
        }
    }
}
