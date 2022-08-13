using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.BudgetUserView;
using BudgetPlannerMVC.Application.ViewModels.UserRoleView;
using BudgetPlannerMVC.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Web.Controllers
{
    [Authorize]
    public class BudgetUserController : Controller
    {
        private readonly IBudgetUserService _budgetUserService;
        private readonly IUserRoleService _userRoleService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public BudgetUserController(IBudgetUserService budgetUserService, 
            IUserRoleService userRoleService, 
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _budgetUserService = budgetUserService;
            _userRoleService = userRoleService;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        [Authorize(Roles = "Admin, User, PreUser")]
        public IActionResult Index()
        {
            var model = _budgetUserService.GetAllBudgetUsersForList(8, 1, "");
            var currentUserId = _userRoleService.GetCurrentUserId();
            model.CurrentUserId = currentUserId;
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin, User, PreUser")]
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
            var currentUserId = _userRoleService.GetCurrentUserId();
            model.CurrentUserId = currentUserId;
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "PreUser")]
        public IActionResult CreateBudgetUserProfile()
        {
            var userId = _userRoleService.GetCurrentUserId();
            var model = _budgetUserService.GetBudgetUserForCreateProfile(userId);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "PreUser")]
        public async Task<IActionResult> CreateBudgetUserProfileAsync(NewBudgetUserVm model, string addContact, string removeContact)
        {
            if (ModelState.IsValid && addContact == null && removeContact == null)
            {
                _budgetUserService.UpdateBudgetUser(model);
                _userRoleService.UpdateUserRole(model.UserId);
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index");
            }
            var allContactTypes = _budgetUserService.CountContactDetailsForAddBudgetUser(model, addContact, removeContact);
            model.CountContactDetailsType = allContactTypes;
            model.ContactDetailTypes = _budgetUserService.DropDownContactDetailTypes();
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult EditBudgetUser(int id)
        {
            var budgetUser = _budgetUserService.GetBudgetUserForEdit(id);
            budgetUser.ContactDetailTypes = _budgetUserService.DropDownContactDetailTypes();
            budgetUser.CountContactDetailsType = budgetUser.ContactDetails.Count - 1;
            var currentUserId = _userRoleService.GetCurrentUserId();
            if (User.IsInRole("User") && budgetUser.UserId != currentUserId)
            {
                return RedirectToAction("Index");
            }
            return View(budgetUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public IActionResult EditBudgetUser(NewBudgetUserVm model, string addContact, string removeContact)
        {
            var currentUserId = _userRoleService.GetCurrentUserId();
            if (ModelState.IsValid && addContact == null && removeContact == null)
            {
                if (User.IsInRole("Admin") || (User.IsInRole("User") && model.UserId == currentUserId))
                {
                    _budgetUserService.UpdateBudgetUser(model);
                }
                return RedirectToAction("Index");
            }
            var allContactTypes = _budgetUserService.CountContactDetailsForAddBudgetUser(model, addContact, removeContact);
            model.CountContactDetailsType = allContactTypes;

            model.ContactDetailTypes = _budgetUserService.DropDownContactDetailTypes();
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var budgetUser = _budgetUserService.GetBudgetUserForEdit(id);
            var roleId = _userRoleService.GetUserRoleIdByUserId(budgetUser.UserId);
            if (roleId == "Admin")
            {
                return RedirectToAction("Index");
            }
            return View(budgetUser);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var budgetUser = _budgetUserService.GetBudgetUserForEdit(id);
            var user = await _userManager.FindByIdAsync(budgetUser.UserId);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                _budgetUserService.DeleteBudgetUser(id);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles = "Admin, User, PreUser")]
        public IActionResult Details(int id)
        {
            var budgetUser = _budgetUserService.GetBudgetUserForEdit(id);
            return View(budgetUser);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditUserRole(string userId)
        {
            var userModel = _userRoleService.GetUserForEditRoleByUserId(userId);
            var userLoggedIn = _userRoleService.GetCurrentUserId();
            if (userLoggedIn == userId && userModel.CountAdminRole <= 1)
            {
                return RedirectToAction("Index");
            }
            return View(userModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUserRoleAsync(EditUserRoleVm editUserRoleVm)
        {
            _userRoleService.UpdateUserRole(editUserRoleVm.UserId, editUserRoleVm.UserRoleId);
            if (editUserRoleVm.UserRoleId == "Admin")
            {
                await _signInManager.SignOutAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
