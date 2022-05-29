using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.PlanView
{
    public class PlanForListVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

       // public PlanTypeVm PlanTypes { get; set; }
    }
}
