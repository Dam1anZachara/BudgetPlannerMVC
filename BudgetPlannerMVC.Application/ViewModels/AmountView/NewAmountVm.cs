using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
using BudgetPlannerMVC.Application.ViewModels.TypeView;
using BudgetPlannerMVC.Domain.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.AmountView
{
    public class NewAmountVm : IMapFrom<Amount>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "...")]
        //[Range(0, 99999999.99)]
        public decimal Value { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public string NameOfType { get; set; }
        public TypeForListVm Type { get; set; }
        public string TypeName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewAmountVm, Amount>().ReverseMap();
            //.ForMember(d => d.NameOfType, opt => opt.Ignore())
            //.ForMember(d => d.Type, opt => opt.Ignore());
        }
        public class NewAmountValidation : AbstractValidator<NewAmountVm>
        {
            public NewAmountValidation()
            {
                RuleFor(x => x.Id).NotNull();
                RuleFor(x => x.Date).NotNull();
                RuleFor(x => x.Value).ScalePrecision(6, 2, true);
                RuleFor(x => x.Description).MaximumLength(255);
                RuleFor(x => x.TypeId).NotNull();
            }
        }
    }
}
