using AutoMapper;
using BudgetPlannerMVC.Application.Interfaces;
using BudgetPlannerMVC.Application.ViewModels.UserRoleView;
using BudgetPlannerMVC.Domain.Interfaces;
using BudgetPlannerMVC.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBudgetUserRepository _budgetUserRepository;
        private readonly IMapper _mapper;

        public UserRoleService(IUserRoleRepository userRoleRepository,
            IHttpContextAccessor httpContextAccessor,
            IBudgetUserRepository budgetUserRepository,
            IMapper mapper)
        {
            _userRoleRepository = userRoleRepository;
            _httpContextAccessor = httpContextAccessor;
            _budgetUserRepository = budgetUserRepository;
            _mapper = mapper;
        }

        public string GetCurrentUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public string GetUserRoleIdByUserId(string userId)
        {
            return _userRoleRepository.GetUserRoleIdByUserId(userId);
        }
        public EditUserRoleVm GetUserForEditRoleByUserId(string userId)
        {
            var budgetUser = _budgetUserRepository.GetAllBudgetUsers().FirstOrDefault(p => p.UserId == userId);
            var editUserRoleVm = _mapper.Map<EditUserRoleVm>(budgetUser);
            var listOfRoles = _userRoleRepository.GetAllUserRolesId();
            var currentUserRole = _userRoleRepository.GetUserRoleIdByUserId(userId);
            var countAdminRole = _userRoleRepository.GetCountAdminRole();
            editUserRoleVm.UserRoles = listOfRoles;
            editUserRoleVm.UserRoleId = currentUserRole;
            editUserRoleVm.CountAdminRole = countAdminRole;
            return editUserRoleVm;
        }
        public void UpdateUserRole(string userId, string roleId = null)
        {
            var budgetUser = _budgetUserRepository.GetAllBudgetUsers().FirstOrDefault(p => p.UserId == userId);
            var budgetUserProfileCreated = budgetUser.ProfileCreated;
            var countAdminUsers = _userRoleRepository.GetCountAdminRole();
            if (roleId == null)
            {
                roleId = SetUserRoleAfterRegisterAndProfileCreated(budgetUserProfileCreated, countAdminUsers, roleId);
            }
            _userRoleRepository.UpdateUserRole(userId, roleId);
        }

        private string SetUserRoleAfterRegisterAndProfileCreated(bool profileCreated, int countAdminUsers, string roleId)
        {
            if (profileCreated == true)
            {
                if (countAdminUsers == 0)
                {
                    roleId = "Admin";
                }
                else
                {
                    roleId = "User";
                }
            }
            else
            {
                roleId = "PreUser";
            }
            return roleId;
        }
    }
}
