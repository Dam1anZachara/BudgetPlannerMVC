using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace BudgetPlannerMVC.Application.ViewModels.TypeView
{
    public class NewTypeVm : IMapFrom<Domain.Model.Type>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AssignId { get; set; }
        public string NameOfAssign { get; set; }
        public AssignForTypeVm Assign { get; set; }
        //public List<AssignForTypeVm> Assigns { get; set; } // do usunięcia?
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewTypeVm, Domain.Model.Type>().ReverseMap();
        }
    }

    public class NewTypeValidation : AbstractValidator<NewTypeVm>
    {
        public NewTypeValidation()
        {
            RuleFor(x => x.Id).NotNull();
            When(x => x.Name == null, () => { RuleFor(x => x.Name).NotEmpty().WithMessage("Name can't be empty"); })
                .Otherwise(() => RuleFor(x => x.Name)
                .Must(name => !name.Contains("-")).WithMessage("Name can't contains \"-\"")
                .MaximumLength(20).WithMessage("Name can't be more than 20 characters"));
            RuleFor(x => x.Description).MaximumLength(255).WithMessage("Description can't be more than 255 characters");
            RuleFor(x => x.AssignId).NotNull();
        }
    }
}
