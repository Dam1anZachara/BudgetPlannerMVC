using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.TypeView;
using BudgetPlannerMVC.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BudgetPlannerMVC.Web.Controllers
{
    [Authorize]
    public class TypeController : Controller
    {
        private readonly ITypeService _typeService;
        private readonly SignInManager<IdentityUser> _signInManager;
        public TypeController(ITypeService typeService, SignInManager<IdentityUser> signInManager)
        {
            _typeService = typeService;
            _signInManager = signInManager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Index()
        {
            var model = _typeService.GetAllTypesForList(8, 1, "");
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
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
        [Authorize(Roles = "Admin, User")]
        public IActionResult AddType()
        {
            var assigns = _typeService.DropDownAssigns();
            var model = new NewTypeVm()
            {
                Assigns = assigns
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public IActionResult AddType(NewTypeVm model)
        {
            if (ModelState.IsValid)
            {
                var id = _typeService.AddType(model);
                return RedirectToAction("Index");
            }
            model.Assigns = _typeService.DropDownAssigns();
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult EditType(int id)
        {
            var type = _typeService.GetTypeForEdit(id);
            type.Assigns = _typeService.DropDownAssigns();
            return View(type);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public IActionResult EditType(NewTypeVm model)
        {
            if (ModelState.IsValid)
            {
                _typeService.UpdateType(model);
                return RedirectToAction("Index");
            }
            model.Assigns = _typeService.DropDownAssigns();
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var type = _typeService.GetTypeForEdit(id);
            return View(type);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(NewTypeVm model)
        {
            _typeService.DeleteType(model.Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Details(int id)
        {
            var type = _typeService.GetTypeForEdit(id);
            return View(type);
        }
    }
}
