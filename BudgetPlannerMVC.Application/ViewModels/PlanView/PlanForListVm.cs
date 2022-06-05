using AutoMapper;
using BudgetPlannerMVC.Application.Mapping;
using BudgetPlannerMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.PlanView
{
    public class PlanForListVm : IMapFrom<Plan>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateStart { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateEnd { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Plan, PlanForListVm>();
        }
    }
}
