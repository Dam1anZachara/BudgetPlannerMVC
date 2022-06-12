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
        //[DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        //[RegularExpression(@"^[0-9]+(\,[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        //[RegularExpression(@"\d{1,20}(\.\d{1,2})?", ErrorMessage = "Invalid Price. Please use the format of XXXX.XX.")]
        //[DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}")]
        //[RegularExpression("([0-9]+)", ErrorMessage = "NumberInvalid")]
        //[RegularExpression(@"^[0-9]{1,3}([0-9]{3})*\,[0-9]+$", ErrorMessage = "Error")]
        //[DisplayFormat(DataFormatString = "{0:C2}")]

        [DataType(DataType.Currency)]
        public decimal Value { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public string NameOfType { get; set; }
        public TypeForListVm Type { get; set; }
        //public string TypeName { get; set; } //do usunięcia?
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
                RuleFor(x => x.Value).NotEmpty().WithMessage("Value can't be empty");
               //RuleFor(x => x.Date).Must(Date => Date.GetDateTimeFormats("dd.MM.yyyy hh:mm"));
               //RuleFor(x => x.Value).ScalePrecision(2, 4, false);
                RuleFor(x => x.Description).MaximumLength(255).WithMessage("Description can't be more than 255 characters");
                RuleFor(x => x.TypeId).NotNull();
            }
        }
    }
}
