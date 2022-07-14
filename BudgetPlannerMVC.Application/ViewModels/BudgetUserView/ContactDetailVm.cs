using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
using BudgetPlannerMVC.Domain.Model;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.BudgetUserView
{
    public class ContactDetailVm : IMapFrom<ContactDetail>
    {
        public int Id { get; set; }
        public string ContactDetailInformation { get; set; }
        public int ContactDetailTypeId { get; set; }
        public ContactDetailTypeVm ContactDetailType { get; set; }
        public int BudgetUserId { get; set; }
        public BudgetUserVm BudgetUser { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContactDetailVm, ContactDetail>().ReverseMap();
            //.ForMember(d => d.Type, opt => opt.Ignore());
        }
        public class NewContactDetailValidation : AbstractValidator<ContactDetailVm>
        {
            public NewContactDetailValidation()
            {
                When(p => p.ContactDetailTypeId == 1, () =>
                {
                    RuleFor(x => x.ContactDetailInformation).NotEmpty().WithMessage("Email can't be empty!")
                    .MaximumLength(26).WithMessage("Email can't be more than 26 characters!")
                    .MinimumLength(6).WithMessage("Email must be more than 6 characters!")
                    .EmailAddress().WithMessage("Invalid email address!");
                }).Otherwise(() =>
                {
                    RuleFor(x => x.ContactDetailInformation).NotEmpty().WithMessage("Phone number can't be empty!")
                    .Matches(@"((?:[0-9]\-?){6,14}[0-9]$)|((?:[0-9]\x20?){6,14}[0-9]$)").WithMessage("Invalid phone number!");
                });
            }
        }
    }
}
