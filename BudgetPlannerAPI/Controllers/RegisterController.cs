using BudgetPlannerMVC.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace BudgetPlannerAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IBudgetUserService _budgetUserService;
        private readonly IUserRoleService _userRoleService;
        public RegisterController(UserManager<IdentityUser> userManager, IBudgetUserService budgetUserService, IUserRoleService userRoleService)
        {
            _userManager = userManager;
            _budgetUserService = budgetUserService;
            _userRoleService = userRoleService;
        }
        [SwaggerOperation("Operation registers new user")]
        [HttpPost]
        public async Task<IActionResult> OnPostAsync(InputModel inputModel)
        {
            var user = new IdentityUser { UserName = inputModel.Email, Email = inputModel.Email, EmailConfirmed = true };
            if (inputModel.Password == inputModel.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(user, inputModel.Password);
                if (result.Succeeded)
                {
                    var budgetUserId = _budgetUserService.AddBudgetUserAfterEmailConfirm(user.Id, user.UserName, user.Email);
                    _budgetUserService.AddAddressForBudgetUserAfterEmailConfirm(budgetUserId);
                    _userRoleService.UpdateUserRole(user.Id);
                }
            }
            return Created("", user);
        }
    }
}
