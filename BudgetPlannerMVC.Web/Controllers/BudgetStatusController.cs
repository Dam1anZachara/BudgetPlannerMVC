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
            var model = _budgetStatusService.GetBudgetStatusForVm();
            return View(model);
        }
    }
}
