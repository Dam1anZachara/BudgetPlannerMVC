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
    public class TypeForListVm : IMapFrom<Domain.Model.Type>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AssignId { get; set; }
        public AssignForListVm Assign { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.Type, TypeForListVm>();
                //.ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                //.ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                //.ForMember(d => d.AssignId, opt => opt.MapFrom(s => s.AssignId));
        }
    }
}
