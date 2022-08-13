using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Domain.Interfaces
{
    public interface IUserRoleRepository
    {
        string GetUserRoleIdByUserId(string id);
        IQueryable<string> GetAllUserRolesId();
        int GetCountAdminRole();
        void UpdateUserRole(string userId, string roleId);
    }
}
