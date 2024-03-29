﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetPlannerMVC.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace BudgetPlannerMVC.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IBudgetUserService _budgetUserService;
        private readonly IUserRoleService _userRoleService;

        public ConfirmEmailModel(UserManager<IdentityUser> userManager, IBudgetUserService budgetUserService, IUserRoleService userRoleService)
        {
            _userManager = userManager;
            _budgetUserService = budgetUserService;
            _userRoleService = userRoleService;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                var budgetUserId = _budgetUserService.AddBudgetUserAfterEmailConfirm(user.Id, user.UserName, user.Email);
                _budgetUserService.AddAddressForBudgetUserAfterEmailConfirm(budgetUserId);
                _userRoleService.UpdateUserRole(userId);
            }
            StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";
            return Page();
        }
    }
}
