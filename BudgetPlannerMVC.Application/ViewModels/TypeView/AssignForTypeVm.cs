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
    public class AssignForTypeVm : IMapFrom<Assign>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Assign, AssignForTypeVm>();
        }
    }
}
