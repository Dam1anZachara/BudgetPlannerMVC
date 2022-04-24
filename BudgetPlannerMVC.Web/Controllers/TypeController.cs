using Microsoft.AspNetCore.Mvc;

namespace BudgetPlannerMVC.Web.Controllers
{
    public class TypeController : Controller
    {
        public IActionResult Index()
        {
            var model = typeService.GetAllTypesForList();
            return View();
        }
        [HttpGet]
        public IActionResult AddAmount()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAmount(AmountModel model)
        {
            var id = customerService.AddAmount(model);
            return View();
        }

    }
}
