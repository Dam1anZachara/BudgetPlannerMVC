using BudgetPlannerMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlannerMVC.Web.Controllers
{
    public class PlanController : Controller
    {
        private readonly IPlanService _planService;
        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    var model = _planService.GetAllPlansForList();
        //    return View();
        //}
        //public IActionResult Index()
        //{

        //}
    }
}
