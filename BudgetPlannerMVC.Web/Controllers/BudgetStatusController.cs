using BudgetPlannerMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlannerMVC.Web.Controllers
{
    public class BudgetStatusController : Controller
    {
        private readonly IBudgetStatusService _budgetStatusService;
        public BudgetStatusController(IBudgetStatusService budgetStatusService)
        {
            _budgetStatusService = budgetStatusService;
        }
        public IActionResult Index()
        {
            var plan = _budgetStatusService.GetActivePlanToBudgetStatusVm();    
            var planTypes = _budgetStatusService.GetPlanTypesOfPlanForBudgetStatusVm(plan);
            var amounts = _budgetStatusService.GetAmountsOutOfPlan(plan, planTypes);
            var sumValues = _budgetStatusService.GetSumValuesForBudgetStatusVm(planTypes, amounts);
            var model = _budgetStatusService.GetBudgetStatusForVm(planTypes, sumValues, plan);
            return View(model);
        }
    }
}
