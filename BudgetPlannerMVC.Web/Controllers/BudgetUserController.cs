using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.BudgetUserView;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BudgetPlannerMVC.Web.Controllers
{
    public class BudgetUserController : Controller
    {
        private readonly IBudgetUserService _budgetUserService;
        public BudgetUserController(IBudgetUserService budgetUserService)
        {
            _budgetUserService = budgetUserService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _budgetUserService.GetAllBudgetUsersForList(8, 1, "");
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
            var model = _budgetUserService.GetAllBudgetUsersForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }
        [HttpGet]
        public IActionResult AddBudgetUser()
        {
            var contactDetailTypes = _budgetUserService.DropDownContactDetailTypes();
            var model = new NewBudgetUserVm()
            {
                ContactDetailTypes = contactDetailTypes
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBudgetUser(NewBudgetUserVm model, string addContact, string removeContact)
        {
            if (ModelState.IsValid && addContact == null && removeContact == null)
            {
                var id = _budgetUserService.AddBudgetUser(model);
                var addressId = _budgetUserService.AddAddressForBudgetUser(model, id);
                _budgetUserService.AddContactDetailsForBudgetUserAdd(model, id);
                return RedirectToAction("Index");
            }
            var allContactTypes = _budgetUserService.CountContactDetailsForAddBudgetUser(model, addContact, removeContact);
            model.CountContactDetailsType = allContactTypes;
            model.ContactDetailTypes = _budgetUserService.DropDownContactDetailTypes();
            return View(model);
        }
        [HttpGet]
        public IActionResult EditBudgetUser(int id)
        {
            var budgetUser = _budgetUserService.GetBudgetUserForEdit(id);
            budgetUser.ContactDetailTypes = _budgetUserService.DropDownContactDetailTypes();
            budgetUser.CountContactDetailsType = budgetUser.ContactDetails.Count - 1;
            return View(budgetUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditBudgetUser(NewBudgetUserVm model, string addContact, string removeContact)
        {
            if (ModelState.IsValid && addContact == null && removeContact == null)
            {
                _budgetUserService.UpdateBudgetUser(model);
                _budgetUserService.UpdateAdressForBudgetUser(model);
                _budgetUserService.AddDeleteUpdateContactDetailsForBudgetUserEdit(model);
                return RedirectToAction("Index");
            }
            var allContactTypes = _budgetUserService.CountContactDetailsForAddBudgetUser(model, addContact, removeContact);
            model.CountContactDetailsType = allContactTypes;
            
            model.ContactDetailTypes = _budgetUserService.DropDownContactDetailTypes();
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var budgetUser = _budgetUserService.GetBudgetUserForEdit(id);
            return View(budgetUser);
        }
        [HttpPost]
        public IActionResult Delete(NewBudgetUserVm model)
        {
            _budgetUserService.DeleteBudgetUser(model.Id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var budgetUser = _budgetUserService.GetBudgetUserForEdit(id);
            return View(budgetUser);
        }
    }
}
