using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlannerMVC.Web.Controllers
{
    public class TypeController : Controller
    {
        private readonly ITypeService _typeService;
        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }
        public IActionResult Index()
        {
            var model = _typeService.GetAllTypesForList();
            return View(model);
        }
        public IActionResult ExpenseTypes()
        {
            var model = _typeService.GetAllExpenseTypesForList();
            return View(model);
        }
        [HttpGet]
        public IActionResult AddType()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult AddType(Type model)
        //{
        //    var id = _typeService.AddType(model);
        //    return View();
        //}

    }
}
