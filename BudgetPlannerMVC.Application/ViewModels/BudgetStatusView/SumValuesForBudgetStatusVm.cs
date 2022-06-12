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
        public decimal SumOfExpenses { get; set; }
        [DataType(DataType.Currency)]
        public decimal SumOfIncomes { get; set; }
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }
        public decimal SumOfExpOutOfPlan { get; set; }
        public decimal SumOfIncOutOfPlan { get; set; }
    }
}
