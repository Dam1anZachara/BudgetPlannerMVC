using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BudgetPlannerMVC.Application.ViewModels.TypeView
{
    public class NewTypeVm : IMapFrom<Domain.Model.Type>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AssignId { get; set; }
        public AssignForTypeVm Assign { get; set; }
        public IQueryable<AssignForTypeVm> Assigns { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewTypeVm, Domain.Model.Type>().ReverseMap();
        }
    }

    public class NewTypeValidation : AbstractValidator<NewTypeVm>
    {
        public NewTypeValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can't be empty")
                .MaximumLength(26).WithMessage("Name can't be more than 26 characters");
            RuleFor(x => x.Description).MaximumLength(255).WithMessage("Description can't be more than 255 characters");
            RuleFor(x => x.AssignId).NotNull();
        }
    }
}
