﻿using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.TypeView
{
    public class NewTypeVm : IMapFrom<Domain.Model.Type>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AssignId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewTypeVm, Domain.Model.Type>().ReverseMap();
        }
    }
}
