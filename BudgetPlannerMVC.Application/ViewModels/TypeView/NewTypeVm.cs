using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
using FluentValidation;
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
        public AssignForTypeVm Assign { get; set; } //do usunięcia?
        public List<AssignForTypeVm> Assigns { get; set; } // do usunięcia?
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
            //RuleFor(x => x.Name).NotEmpty().Must(name => name != "-");
            RuleFor(x => x.Name).NotEmpty().Must(name => !name.Contains("-")).MaximumLength(8);
            //RuleFor(x => x.Name).MaximumLength(20);
            RuleFor(x => x.Description).MaximumLength(255).WithMessage("Description can't be more than 255 characters");
            RuleFor(x => x.AssignId).NotNull();
            //RuleFor(x => x.Name).NotEqual("-");
        }
    }
}
