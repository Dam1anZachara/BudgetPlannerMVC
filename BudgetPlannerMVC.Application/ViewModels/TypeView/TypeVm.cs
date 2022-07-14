using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
using BudgetPlannerMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.TypeView
{
    public class TypeVm : IMapFrom<Domain.Model.Type>
    {
        public int Id { get; set; }
        public string NameAndAssign { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.Type, TypeVm>()
            .ForMember(d => d.NameAndAssign, opt => opt.MapFrom(s => s.Name + " - " + s.Assign.Name));
        }
    }
}
