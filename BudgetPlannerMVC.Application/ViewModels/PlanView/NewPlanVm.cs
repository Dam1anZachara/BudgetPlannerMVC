using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
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
    public class NewPlanVm : IMapFrom<Plan>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateStart { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateEnd { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewPlanVm, Plan>().ReverseMap();
        }
        public class NewPlanValidation : AbstractValidator<NewPlanVm>
        {
            public NewPlanValidation()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Name can't be empty")
                    .MaximumLength(26).WithMessage("Name can't be more than 26 characters");
                RuleFor(x => x.DateEnd).GreaterThanOrEqualTo(x => x.DateStart).WithMessage("Start Date can't be greater than End Date");
                RuleFor(x => x.DateStart).LessThanOrEqualTo(x => x.DateEnd).WithMessage("Start Date can't be greater than End Date");
            }
        }
    }
}
