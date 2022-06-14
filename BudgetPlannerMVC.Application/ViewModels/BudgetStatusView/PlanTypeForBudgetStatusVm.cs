using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
using BudgetPlannerMVC.Application.ViewModels.PlanView;
using BudgetPlannerMVC.Application.ViewModels.TypeView;
using BudgetPlannerMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.BudgetStatusView
{
    public class PlanTypeForBudgetStatusVm : IMapFrom<PlanType>
    {
        public int Id { get; set; }
        [DataType(DataType.Currency)]
        public decimal Value { get; set; }
        [DataType(DataType.Currency)]
        public decimal AmountValues { get; set; }
        [DataType(DataType.Currency)]
        public decimal DifferenceValue { get; set; }
        public int TypeId { get; set; }
        public int PlanId { get; set; }

        public TypeForListVm Type { get; set; }
        public PlanForListVm Plan { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<PlanType, PlanTypeForBudgetStatusVm>()
                .ForMember(d => d.AmountValues, opt => opt.Ignore())
                .ForMember(d => d.DifferenceValue, opt => opt.Ignore());
        }
    }
}
