using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
using BudgetPlannerMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.BudgetUserView
{
    public class BudgetUserVm : IMapFrom<BudgetUser>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<BudgetUser, BudgetUserVm>()
            .ForMember(d => d.FullName, opt => opt.MapFrom(s => s.LastName + " " + s.FirstName));
        }
    }
}
