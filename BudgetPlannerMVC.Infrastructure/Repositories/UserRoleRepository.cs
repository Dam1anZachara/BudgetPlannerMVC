using BudgetPlannerMVC.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Infrastructure.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        readonly Context _context;
        public UserRoleRepository(Context context)
        {
            _context = context;
        }
        public string GetUserRoleIdByUserId(string id)
        {
            return _context.UserRoles.FirstOrDefault(u => u.UserId == id).RoleId;
        }
        public IQueryable<string> GetAllUserRolesId()
        {
            return _context.Roles.Select(p => p.Id);
        }
        public int GetCountAdminRole()
        {
            return _context.UserRoles.Where(p => p.RoleId == "Admin").Count();
        }
        public void UpdateUserRole(string userId, string roleId)
        {
            var userExist = _context.Users.Where(p => p.Id == userId);
            var userCurrentRole = _context.UserRoles.FirstOrDefault(u => u.UserId == userId);
            if (!(userExist is null))
            {
                var userNewRole = new IdentityUserRole<string>()
                {
                    UserId = userId,
                    RoleId = roleId
                };
                if (!(userCurrentRole is null))
                {
                    _context.Remove(userCurrentRole);
                }
                _context.Add(userNewRole);
                _context.SaveChanges();
            }
        }
    }
}
