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
            //var model = _typeService.GetAllTypesForList();
            return View();
        }
        [HttpGet]
        public IActionResult ExpenseTypes()
        {
            var model = _typeService.GetAllExpenseTypesForList(2, 1, "");
            return View(model);
        }
        [HttpPost]
        public IActionResult ExpenseTypes(int pageSize, int pageNo, string searchString)
        {
            var model = _typeService.GetAllExpenseTypesForList(pageSize, pageNo, searchString);
            return View(model);
        }
        public IActionResult IncomeTypes()
        {
            var model = _typeService.GetAllIncomeTypesForList();
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
