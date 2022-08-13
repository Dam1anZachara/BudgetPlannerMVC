using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
using BudgetPlannerMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.UserRoleView
{
    public class EditUserRoleVm : IMapFrom<BudgetUser>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string MainMail { get; set; }
        public bool ProfileCreated { get; set; }
        public string UserRoleId { get; set; }
        public int CountAdminRole { get; set; }
        public IQueryable<string> UserRoles { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EditUserRoleVm, BudgetUser>().ReverseMap();
        }
    }
}
