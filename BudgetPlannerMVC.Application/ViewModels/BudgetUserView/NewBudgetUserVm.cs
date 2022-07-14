using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
using BudgetPlannerMVC.Domain.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BudgetPlannerMVC.Application.ViewModels.BudgetUserView.AddressVm;
using static BudgetPlannerMVC.Application.ViewModels.BudgetUserView.ContactDetailVm;

namespace BudgetPlannerMVC.Application.ViewModels.BudgetUserView
{
    public class NewBudgetUserVm : IMapFrom<BudgetUser>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountContactDetailsType { get; set; }
        public AddressVm Address { get; set; }
        public List<ContactDetailVm> ContactDetails { get; set; }
        public List<AddressVm> Addresses { get; set; }
        public IQueryable<ContactDetailTypeVm> ContactDetailTypes { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewBudgetUserVm, BudgetUser>().ReverseMap()
                .ForMember(d => d.CountContactDetailsType, opt => opt.Ignore());
            //.ForMember(d => d.Address, opt => opt.MapFrom(s => s.Addresses.First(p => p.BudgetUserId == Id)));
            //.ForMember(d => d.ContactDetails, opt => opt.Ignore())
            //.ForMember(d => d.ContactDetailTypes, opt => opt.Ignore());    
        }
        public class NewBudgetUserValidation : AbstractValidator<NewBudgetUserVm>
        {
            public NewBudgetUserValidation()
            {
                RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name can't be empty!")
                    .MaximumLength(26).WithMessage("First Name can't be more than 26 characters!");
                RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name can't be empty!")
                    .MaximumLength(26).WithMessage("Last Name can't be more than 26 characters!");
                RuleForEach(x => x.ContactDetails).SetValidator(new NewContactDetailValidation());
                RuleFor(x => x.Address).SetValidator(new NewAddressValidation());
            }
        }
    }
}
