using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
using BudgetPlannerMVC.Application.ViewModels.TypeView;
using BudgetPlannerMVC.Domain.Model;
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
    }
}
