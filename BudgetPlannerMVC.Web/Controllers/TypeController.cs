using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.TypeView;
using BudgetPlannerMVC.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BudgetPlannerMVC.Web.Controllers
{
    public class TypeController : Controller
    {
        private readonly ITypeService _typeService;
        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _typeService.GetAllTypesForList(3, 1, "");
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _typeService.GetAllTypesForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddType(string x)
        {
            ViewBag.list = _typeService.DropDownAssigns();
            return View(new NewTypeVm());
        }
        [HttpPost]
        public IActionResult AddType(NewTypeVm model)
        {
            //model.AssignId = 1;
            var id = _typeService.AddType(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditType(int id)
        {
            var type = _typeService.GetTypeForEdit(id);
            return View(type);
        }
        [HttpPost]
        public IActionResult EditType(NewTypeVm model)
        {
            if (ModelState.IsValid)
            {
                _typeService.UpdateType(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _typeService.DeleteType(id);
            return RedirectToAction("Index");
        }
    }
}
