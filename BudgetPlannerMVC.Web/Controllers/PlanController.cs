using Microsoft.AspNetCore.Mvc;

namespace BudgetPlannerMVC.Web.Controllers
{
    public class PlanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
