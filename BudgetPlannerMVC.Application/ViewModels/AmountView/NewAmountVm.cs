using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
using BudgetPlannerMVC.Application.ViewModels.BudgetUserView;
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
        [DataType(DataType.Currency)]
        public decimal Value { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public TypeForListVm Type { get; set; }
        public IQueryable<TypeVm> Types { get; set; }
        public int BudgetUserID { get; set; }
        public BudgetUserVm BudgetUser { get; set; }
        public IQueryable<BudgetUserVm> BudgetUsers { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewAmountVm, Amount>().ReverseMap();
        }
        public class NewAmountValidation : AbstractValidator<NewAmountVm>
        {
            public NewAmountValidation()
            {
                RuleFor(x => x.Id).NotNull();
                RuleFor(x => x.Date).NotNull();
                RuleFor(x => x.Value).NotEmpty().WithMessage("Value can't be empty")
                    .ScalePrecision(2, 18, true).WithMessage("Wrong format for \"Value\"");
                RuleFor(x => x.Description).MaximumLength(255).WithMessage("Description can't be more than 255 characters");
                RuleFor(x => x.TypeId).NotNull();
            }
        }
    }
}
