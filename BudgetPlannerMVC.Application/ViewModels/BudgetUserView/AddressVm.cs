using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
using BudgetPlannerMVC.Domain.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.BudgetUserView
{
    public class AddressVm : IMapFrom<Address>
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public int FlatNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int BudgetUserId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddressVm, Address>().ReverseMap();
        }
        public class NewAddressValidation : AbstractValidator<AddressVm>
        {
            public NewAddressValidation()
            {
                RuleFor(x => x.Street).NotEmpty().WithMessage("Street can't be empty!")
                    .MaximumLength(26).WithMessage("Street can't be more than 26 characters!");
                RuleFor(x => x.BuildingNumber).NotEmpty().WithMessage("Building number can't be empty!").
                    MaximumLength(9).WithMessage("Building number can't be more than 9 characters!");
                RuleFor(x => x.FlatNumber).NotEmpty().WithMessage("Flat number can't be empty");
                RuleFor(x => x.ZipCode).NotEmpty().WithMessage("Zip Code can't be empty!")
                    .Matches(@"^[0-9]{2}-[0-9]{3}").WithMessage("Invalid Zip Code! Zip Code must be in format: \"NN-NNN\"");
                RuleFor(x => x.City).NotEmpty().WithMessage("City can't be empty!")
                    .MaximumLength(26).WithMessage("City can't be more than 26 characters!");
                RuleFor(x => x.Country).NotEmpty().WithMessage("Country can't be empty!")
                    .MaximumLength(26).WithMessage("Country can't be more than 26 characters!");
            }
        }
    }
}
