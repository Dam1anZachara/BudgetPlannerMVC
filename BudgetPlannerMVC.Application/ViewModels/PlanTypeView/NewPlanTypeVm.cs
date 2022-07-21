using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
using BudgetPlannerMVC.Application.ViewModels.PlanTypeView;
using BudgetPlannerMVC.Application.ViewModels.TypeView;
using BudgetPlannerMVC.Domain.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.PlanView
{
    public class NewPlanTypeVm : IMapFrom<PlanType>
    {
        public int Id { get; set; }
        [DataType(DataType.Currency)]
        public decimal Value { get; set; }
        public int TypeId { get; set; }
        public int PlanId { get; set; }
        public List<PlanTypeVm> PlanTypes { get; set; }
        public TypeForListVm Type { get; set; }
        public PlanForListVm Plan { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewPlanTypeVm, PlanType>().ReverseMap();
        }
        public class NewPlanTypeValidation : AbstractValidator<NewPlanTypeVm>
        {
            public NewPlanTypeValidation()
            {
                RuleFor(x => x.Value).ScalePrecision(2, 18, true).WithMessage("Wrong format for \"Value\"");
            }
        }
    }
}
