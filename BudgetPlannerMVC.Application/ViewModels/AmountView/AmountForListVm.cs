using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
using BudgetPlannerMVC.Application.ViewModels.TypeView;
using BudgetPlannerMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.AmountView
{
    public class AmountForListVm : IMapFrom<Amount>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public TypeForListVm Type { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Amount, AmountForListVm>()
                .ForMember(d => d.Type, opt => opt.Ignore());
        }
    }
}
