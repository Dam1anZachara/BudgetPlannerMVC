using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Application.ViewModels.BudgetStatusView
{
    public class SumValuesForBudgetStatusVm
    {
        [DataType(DataType.Currency)]
        public decimal SumOfExpPlan { get; set; }
        [DataType(DataType.Currency)]
        public decimal SumOfIncPlan { get; set; }
        [DataType(DataType.Currency)]
        public decimal BalancePlan { get; set; }
        [DataType(DataType.Currency)]
        public decimal SumOfExpOutOfPlan { get; set; }
        [DataType(DataType.Currency)]
        public decimal SumOfIncOutOfPlan { get; set; }
        [DataType(DataType.Currency)]
        public decimal BalanceOutOfPlan { get; set; }
        [DataType(DataType.Currency)]
        public decimal ExpensesTotal { get; set; }
        [DataType(DataType.Currency)]
        public decimal IncomesTotal { get; set; }
        [DataType(DataType.Currency)]
        public decimal BalanceTotal { get; set; }
    }
}
