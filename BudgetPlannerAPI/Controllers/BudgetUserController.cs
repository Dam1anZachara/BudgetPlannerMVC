using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.BudgetUserView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BudgetPlannerAPI.Controllers
{
    //[Authorize]
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
        //[Authorize(Roles = "Admin, User, PreUser")]
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
        [HttpPut]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "PreUser")]
        public async Task<IActionResult> CreateBudgetUserProfileAsync(NewBudgetUserVm model)
        {
            _budgetUserService.UpdateBudgetUser(model);
            _userRoleService.UpdateUserRole(model.UserId);
            await _signInManager.SignOutAsync();
            return NoContent();
        }
        [Route("Edit")]
        [HttpPut]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin, User")]
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
    }
}
