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
            var model = _typeService.GetAllTypesForList(6, 1, "");
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
        public IActionResult AddType()
        {
            ViewBag.list = _typeService.DropDownAssigns();
            //var model = new NewTypeVm();
            //_typeService.GetAllAssignsForList(model);
            return View(new NewTypeVm());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddType(NewTypeVm model)
        {
            var nameOfAssign = model.NameOfAssign;
            var assignId = _typeService.GetAssignIdByName(nameOfAssign);
            model.AssignId = assignId;
            if (ModelState.IsValid)
            {
                var id = _typeService.AddType(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult EditType(int id)
        {
            ViewBag.list = _typeService.DropDownAssigns();
            var type = _typeService.GetTypeForEdit(id);
            return View(type);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditType(NewTypeVm model)
        {
            var nameOfAssign = model.NameOfAssign;
            var assignId = _typeService.GetAssignIdByName(nameOfAssign);
            model.AssignId = assignId;
            if (ModelState.IsValid)
            {
                _typeService.UpdateType(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var type = _typeService.GetTypeForEdit(id);
            return View(type);
        }
        [HttpPost]
        public IActionResult Delete(NewTypeVm model)
        {
            _typeService.DeleteType(model.Id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var type = _typeService.GetTypeForEdit(id);
            return View(type);
        }
    }
}
