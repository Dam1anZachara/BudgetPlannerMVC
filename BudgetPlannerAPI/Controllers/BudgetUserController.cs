using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.BudgetUserView;
using BudgetPlannerMVC.Application.ViewModels.UserRoleView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerOperation("Operation gets filtered budget users")]
        [Authorize(Roles = "Admin, User, PreUser")]
        [HttpGet]
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
        [SwaggerOperation("Operation gets specific budget user by id")]
        [Authorize(Roles = "Admin, User, PreUser")]
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var budgetUser = _budgetUserService.GetBudgetUserForEdit(id);
            return Ok(budgetUser);
        }
        [SwaggerOperation("Operation creates budget user profile")]
        [Authorize(Roles = "PreUser")]
        [HttpPut]
        public async Task<IActionResult> CreateBudgetUserProfileAsync(NewBudgetUserVm model)
        {
            _budgetUserService.UpdateBudgetUser(model);
            _userRoleService.UpdateUserRole(model.UserId);
            await _signInManager.SignOutAsync();
            return NoContent();
        }
        [SwaggerOperation("Operation edits budget user")]
        [Route("Edit")]
        [Authorize(Roles = "Admin, User")]
        [HttpPut]
        public IActionResult EditBudgetUser(NewBudgetUserVm model)
        {
            if (User.IsInRole("Admin") || User.IsInRole("User"))
            {
                _budgetUserService.UpdateBudgetUser(model);
                return NoContent();
            }
            return BadRequest();
        }
        [SwaggerOperation("Operation edits budget user's role")]
        [Route("Role/Edit")]
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult EditUserRoleAsync(EditUserRoleVm editUserRoleVm)
        {
            _userRoleService.UpdateUserRole(editUserRoleVm.UserId, editUserRoleVm.UserRoleId);
            return NoContent();
        }

        [SwaggerOperation("Operation deletes budget user")]
        [Authorize(Roles = "Admin")]
        [HttpDelete]
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
