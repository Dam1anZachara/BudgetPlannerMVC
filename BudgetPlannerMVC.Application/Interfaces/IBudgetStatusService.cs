using BudgetPlannerMVC.Application.ViewModels.BudgetStatusView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.Interfaces
{
    public interface IBudgetStatusService
    {
        BudgetStatusVm GetBudgetStatusForVm();
    }
}
