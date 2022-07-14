using BudgetPlannerMVC.Application.ViewModels.AmountView;
using BudgetPlannerMVC.Application.ViewModels.BudgetStatusView;
using BudgetPlannerMVC.Application.ViewModels.PlanView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.Interfaces
{
    public interface IBudgetStatusService
    {
        BudgetStatusVm GetBudgetStatusForVm(List<PlanTypeForBudgetStatusVm> planTypes, SumValuesForBudgetStatusVm sumValues, PlanForListVm plan);
        PlanForListVm GetActivePlanToBudgetStatusVm();
        List<PlanTypeForBudgetStatusVm> GetPlanTypesOfPlanForBudgetStatusVm(PlanForListVm plan);
        SumValuesForBudgetStatusVm GetSumValuesForBudgetStatusVm(List<PlanTypeForBudgetStatusVm> planTypes, List<AmountForListVm> amounts);
        List<AmountForListVm> GetAmountsOutOfPlan(PlanForListVm plan, List<PlanTypeForBudgetStatusVm> planTypes);
    }
}
