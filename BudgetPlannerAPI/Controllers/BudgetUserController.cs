using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.BudgetUserView;
using BudgetPlannerMVC.Application.ViewModels.UserRoleView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BudgetPlannerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetUserController : ControllerBase
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
        public IActionResult GetBudgetUsers(int pageSize, int? pageNo, string searchString)
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
            return Ok(model);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, User, PreUser")]
        public IActionResult Details(int id)
        {
            var budgetUser = _budgetUserService.GetBudgetUserForEdit(id);
            return Ok(budgetUser);
        }
        [HttpPut]
        [Authorize(Roles = "PreUser")]
        public async Task<IActionResult> CreateBudgetUserProfileAsync(NewBudgetUserVm model)
        {
            _budgetUserService.UpdateBudgetUser(model);
            _userRoleService.UpdateUserRole(model.UserId);
            await _signInManager.SignOutAsync();
            return NoContent();
        }
        [Route("Edit")]
        [HttpPut]
        [Authorize(Roles = "Admin, User")]
        public IActionResult EditBudgetUser(NewBudgetUserVm model)
        {
            var currentUserId = _userRoleService.GetCurrentUserId();
            if (User.IsInRole("Admin") || (User.IsInRole("User") && model.UserId == currentUserId))
            {
                _budgetUserService.UpdateBudgetUser(model);
                return NoContent();
            }
            return BadRequest();
        }
        [Route("Role/Edit")]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUserRoleAsync(EditUserRoleVm editUserRoleVm)
        {
            _userRoleService.UpdateUserRole(editUserRoleVm.UserId, editUserRoleVm.UserRoleId);
            if (editUserRoleVm.UserRoleId == "Admin")
            {
                await _signInManager.SignOutAsync();
            }
            return NoContent();
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var budgetUser = _budgetUserService.GetBudgetUserForEdit(id);
            var user = await _userManager.FindByIdAsync(budgetUser.UserId);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                _budgetUserService.DeleteBudgetUser(id);
                return NoContent();
            }
            return BadRequest();
        }
    }
}
