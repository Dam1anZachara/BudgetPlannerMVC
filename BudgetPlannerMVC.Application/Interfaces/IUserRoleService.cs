using BudgetPlannerMVC.Application.ViewModels.UserRoleView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.Interfaces
{
    public interface IUserRoleService
    {
        string GetCurrentUserId();
        string GetUserRoleIdByUserId(string userId);
        EditUserRoleVm GetUserForEditRoleByUserId(string userId);
        void UpdateUserRole(string userId, string roleId = null);
    }
}
