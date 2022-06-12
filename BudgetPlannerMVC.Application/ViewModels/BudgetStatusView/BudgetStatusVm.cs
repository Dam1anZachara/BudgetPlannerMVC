using BudgetPlannerMVC.Application.ViewModels.AmountView;
using BudgetPlannerMVC.Application.ViewModels.PlanView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.BudgetStatusView
{
    public class BudgetStatusVm
    {
        public SumValuesForBudgetStatusVm SumValues { get; set; }
        public List<PlanTypeForBudgetStatusVm> PlanTypes { get; set; }
    }
}
