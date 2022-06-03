﻿using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
using BudgetPlannerMVC.Application.ViewModels.TypeView;
using BudgetPlannerMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.PlanView
{
    public class PlanTypeForListVm : IMapFrom<PlanType>
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int? TypeId { get; set; }
        public int PlanId { get; set; }

        public TypeForListVm Type { get; set; }
        public PlanForListVm Plan { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<PlanType, PlanTypeForListVm>();
        }
    }
}