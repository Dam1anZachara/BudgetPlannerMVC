using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
using FluentValidation;

namespace BudgetPlannerMVC.Application.ViewModels.TypeView
{
    public class NewTypeVm : IMapFrom<Domain.Model.Type>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AssignId { get; set; }
        public string NameOfAssign { get; set; }
        public TypeForListVm Type { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewTypeVm, Domain.Model.Type>().ReverseMap()
            .ForMember(d => d.NameOfAssign, opt => opt.Ignore())
            .ForMember(d => d.Type, opt => opt.Ignore());
        }
    }

    public class NewTypeValidation : AbstractValidator<NewTypeVm>
    {
        public NewTypeValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(20);
            RuleFor(x => x.Name).NotEqual("-");
        }
    }
}
